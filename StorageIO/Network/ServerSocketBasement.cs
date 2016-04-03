using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Net;
using System.Threading;

using StorageIO.Network.JSON;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace StorageIO.Network
{
    public class ServerSocketBasement
    {
        const int resultLenth = 16777216;

        public static string ipAddr = "127.0.0.1";
        public static int port = 12580;
        public int maxClients = 10, nowClients = 0;
        Socket serverSocket;
        serverMainHandler mainHandler;
        public ServerPage page;

        public JsonSocketModule[] modules = new JsonSocketModule[16];
        public bool[] isUsing = new bool[15];

        public bool Start()
        {
            try
            {
                mainHandler = serverMainHandler.GetSingleton();

                IPAddress ip = IPAddress.Parse(ipAddr);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, port));  //绑定IP地址：端口  
                serverSocket.Listen(maxClients);    //设定最多maxClient个排队连接请求  

                //注册JsonSocketModule模块
                modules[(int)workType.STORE_IMPORT] = new ImportToStore();
                ((ImportToStore)modules[(int)workType.STORE_IMPORT]).store = mainHandler.GetStore();

                modules[(int)workType.STORE_EXPORT] = new ExportFromStore();
                ((ExportFromStore)modules[(int)workType.STORE_EXPORT]).store = mainHandler.GetStore();

                modules[(int)workType.STORE_VIEW_PRODUCT] = new ViewStoreProduct();
                ((ViewStoreProduct)modules[(int)workType.STORE_VIEW_PRODUCT]).store = mainHandler.GetStore();

                //开启监听
                Thread serverThread = new Thread(ListenClientConnect);
                serverThread.Start();

                return true;
            }
            catch
            {
                Console.WriteLine("Server Start Failure!");
                return false;
            }
        }

        public bool Shutdown()
        {
            try
            {
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        
        void ListenClientConnect()
        {
            while (true)
            {
                //监听到客户端连接，开启新线程处理客户端的消息
                Socket clientSocket = serverSocket.Accept();
                nowClients++;
                Thread receiveThread = new Thread(RecieveClientMessage);
                receiveThread.Start(clientSocket);
            }
        }

        void RecieveClientMessage(object clientSocket)
        {
            Socket targetClientSocket = (Socket)clientSocket;
            byte[] result = new byte[resultLenth];
            int len = 0;

            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    len = targetClientSocket.Receive(result);
                    Console.WriteLine(len.ToString());

                    string jsonString = Encoding.Default.GetString(result, 0, len);

                    JObject jobj = JObject.Parse(jsonString);

                    //找到相应的模块进行处理
                    string response = modules[(int)jobj["type"]].GetObjectServer(jsonString);

                    Console.WriteLine(response.Length.ToString());

                    targetClientSocket.Send(Encoding.Default.GetBytes(response));
                    result = new byte[resultLenth];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    targetClientSocket.Shutdown(SocketShutdown.Both);
                    targetClientSocket.Close();
                    nowClients--;
                    break;
                }
            }
        }
    }
}
