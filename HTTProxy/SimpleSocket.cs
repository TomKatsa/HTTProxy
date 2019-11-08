using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace HTTProxy
{
    class SimpleSocket
    {
    private IPAddress ip;
        private int port;
        private Socket sock;
        private Socket listenSocket;

        public SimpleSocket()
        {
            this.ip = IPAddress.Parse("127.0.0.1");
            this.port = 8080;
            this.listenSocket = SimpleSocket.Listen(this.ip, this.port);
        }

        public SimpleSocket(string ip, int port)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = port;
            this.sock = SimpleSocket.Connect(this.ip, this.port);
            this.sock.ReceiveTimeout = 3000;
        }

        public void Accept()
        {
            this.sock = this.listenSocket.Accept();
            this.sock.ReceiveTimeout = 3000;
            this.sock.SendTimeout = 3000;
        }

        public static Socket Listen(IPAddress ip, int port)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind((EndPoint)ipEndPoint);
            socket.Listen(1);
            return socket;
        }

        public static Socket Connect(IPAddress ip, int port)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect((EndPoint)ipEndPoint);
            return socket;
        }

        public void Dispose()
        {
            this.sock.Shutdown(SocketShutdown.Both);
            this.sock.Close();
            this.sock.Dispose();
            //int num1 = (int)MessageBox.Show(this.sock.IsBound.ToString());
            //int num2 = (int)MessageBox.Show("Disposed.");
        }

        public void Send(byte[] msg)
        {
            this.sock.Send(msg);
        }

        public byte[] Recv()
        {
            try
            {
                byte[] buffer = new byte[50000];
                this.sock.Receive(buffer);
                return buffer;
            }
            catch
            {
                return (byte[])null;
            }
        }

        public static string Resolve(string host)
        {
            try
            {
                return Dns.GetHostEntry(host).AddressList[0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string MatchHost(string request)
        {
            string str = Regex.Match(request, "Host: .*\\w").Value.ToString().Split(' ')[1];
            if (str.Contains(":"))
                str = str.Split(':')[0];
            return str;
        }

        public bool Connected()
        {
            if (this.sock == null)
                return false;
            return this.sock.Connected;
        }

        public static byte[] StrToBytes(string x)
        {
            return Encoding.ASCII.GetBytes(x);
        }

        public static string BytesToStr(byte[] x)
        {
            return Encoding.ASCII.GetString(x);
        }

        public void Close()
        {
            this.sock.Close();
        }
    }
}

