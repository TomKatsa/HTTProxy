using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HTTProxy
{
    class BrowserServer
    {
        NetworkStream stream;
        private TcpListener server;
        private TcpClient browser;
        public BrowserServer(string ip, int port)
        {
            server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
        }


        public void Accept()
        {
            if (browser != null)
            {
                browser.Close();
                stream.Close();
            }
            browser = server.AcceptTcpClient();
            stream = browser.GetStream();
        }

        public byte[] Recv()
        {
                byte[] data = new byte[32000];
                stream.Read(data, 0, 32000);
                return data;

        }

        public void Send(byte[] data)
        {
                stream.Write(data, 0, data.Length);

        }

    }
}
