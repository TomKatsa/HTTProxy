using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace HTTProxy
{
    class WebConnection
    {
        NetworkStream stream;
        private TcpClient client;
        private int BlockSize;
        bool failed;

        public bool Failed { get => failed; set => failed = value; }

        public WebConnection()
        {
            BlockSize = 1048576; // 1 MB Size
            client = new TcpClient();
            client.ReceiveTimeout = 3000;
            client.SendTimeout = 3000;
        }
        public void Connect(string host, int port)
        {
            if (client.Connected)
            {
                stream.Close();
                client.Close();
                client = new TcpClient();
                client.ReceiveTimeout = 3000;
                client.SendTimeout = 3000;
            }
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();
                failed = false;
            }
            catch
            {
                failed = true;
            }

        }
        public byte[] Recv()
        {
                byte[] buffer = new byte[BlockSize];
                stream.Read(buffer, 0, BlockSize);
                return buffer;
        }

        public void Send(byte[] buffer)
        {
                stream.Write(buffer, 0, buffer.Length);
        }


        public static string ParseHost(string request) // Match the host from the request using regex
        {
            Match match = Regex.Match(request, @"Host: .*\w");
            if (!match.Success) return "";
            string host = match.ToString().Split(' ')[1];
            return host;
        }
    }
}
