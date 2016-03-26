using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace StorageIO.Network
{
    public class ServerSocketBasement
    {
        const int resultLenth = 2048;

        public static string ipAddr = "127.0.0.1";
        public static int port = 12580;
        public int maxClients = 10, nowClients = 0;
        Socket serverSocket;

        public bool Start()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddr);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, port));  //绑定IP地址：端口  
                serverSocket.Listen(maxClients);    //设定最多10个排队连接请求  

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
                Socket clientSocket = serverSocket.Accept();
                nowClients++;
                //clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                Thread receiveThread = new Thread(RecieveClientMessage);
                receiveThread.Start(clientSocket);
            }
        }

        void RecieveClientMessage(object clientSocket)
        {
            Socket targetClientSocket = (Socket)clientSocket;
            byte[] result = new byte[resultLenth];
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    targetClientSocket.Receive(result);
                    targetClientSocket.Send(result);
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
