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
    class BrowserConnection
    {
        NetworkStream stream;
        private TcpListener server;
        private TcpClient browser;
        public BrowserConnection(string ip, int port)
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
            browser.ReceiveTimeout = 3000;
            browser.SendTimeout = 3000;
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
            if (stream != null && data != null)
            {
                stream.Write(data, 0, data.Length);
            }


        }

    }
}
