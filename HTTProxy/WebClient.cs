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
    class WebClient
    {
        NetworkStream stream;
        private TcpClient client;
        private int BlockSize;
        public WebClient()
        {
            BlockSize = 32000;
            client = new TcpClient();
        }
        public void Connect(string host, int port)
        {
            if (client.Connected)
            {
                stream.Close();
                client.Close();
                client = new TcpClient();
            }
            client.Connect(host, port);
            stream = client.GetStream();
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


        public static string ParseHost(string request)
        {
            Match match = Regex.Match(request, @"Host: .*\w");
            string host = match.ToString().Split(' ')[1];
            return host;
        }
    }
}
