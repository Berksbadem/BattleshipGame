using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Battleship1
{
    public static class Oyuncular
    {
        public static string name;
        public static bool Host = false;
        public static Socket socket;
        public static Stream stream;
        public static IPAddress IP =IPAddress.Parse("127.1.1.1");
        public static TcpListener listener = new TcpListener(IP,3000);
        public static TcpClient client = new TcpClient();
        public static bool HostConnect()
        {
            listener.Start();
            socket = listener.AcceptSocket();
            listener.Stop();
            Host = true;
            return true;
        }
        public static bool ClientConnect()
        {
            Host = false;
            try
            {
                client.Connect("127.1.1.1",3000);
                stream = client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static string HostReceiveButton()
        {
            int i;
            listener.Start();
            byte[] buffer = new byte[100];
            int bnum = socket.Receive(buffer);
            string receivedButtonN = "";
            for (i = 0; i < bnum; i++)
            {
                receivedButtonN += Convert.ToChar(buffer[i]);
            }
            listener.Stop();
            return receivedButtonN;
        }
        public static void HostSendButton(string SentButtonN)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            socket.Send(encoding.GetBytes(SentButtonN));

        }
        public static string ClientReceiveButton()
        {
            int i;
            byte[] buffer = new byte[100];
            int bnum = stream.Read(buffer, 0, buffer.Length);
            string receivedButtonN = "";
            for (i = 0; i < bnum; i++)
            {
                receivedButtonN += Convert.ToChar(buffer[i]);

            }
            return receivedButtonN;
        }
        public static void ClientSendButton(string SentButtonN)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] buffer = encoding.GetBytes(SentButtonN);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}