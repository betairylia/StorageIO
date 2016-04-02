using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace StorageIO.Network
{
    public class ClientSocketBasement
    {
        const int resultLenth = 2048;
        byte[] result = new byte[resultLenth];
        public static int port = 12580;
        Socket clientSocket;

        public bool ConnectServer(string ipAddr)
        {
            IPAddress ip = IPAddress.Parse(ipAddr);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(new IPEndPoint(ip, port));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed!");
                return false;
                //throw;
            }
        }

        public void SendToServer(string jsonString)
        {
            clientSocket.Send(Encoding.Default.GetBytes(jsonString));
            return;
        }

        public string SendToServerAndWait(string jsonString)
        {
            SendToServer(jsonString);
            return RecieveServer();
        }

        public string RecieveServer()
        {
            result = new byte[resultLenth];
            int len = clientSocket.Receive(result);
            return Encoding.Default.GetString(result, 0, len);
        }
    }
}
