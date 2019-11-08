using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HTTProxy
{
    public partial class Form1 : Form
    {
        private Thread background;
        private BrowserServer browser;
        private WebClient web;
        public void BackgroundThread()
        {
            browser.Accept();
            byte[] request = browser.Recv();
            WriteRequest(ASCIIEncoding.ASCII.GetString(request));
        }
        public void WriteRequest(string text)
        {
            if (RequestBox.InvokeRequired)
            {
                RequestBox.Invoke((MethodInvoker)(() =>
               RequestBox.Text = text
                ));
            }
            else
            {
                RequestBox.Text = text;
            }
        }


        public Form1()
        {
            web = new WebClient();
            browser = new BrowserServer("127.0.0.1", 8080);
            background = new Thread(BackgroundThread);
            background.IsBackground = true;
            background.Start();
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string req = RequestBox.Text;
            if (!background.IsAlive || req != "")
            {
                string host = WebClient.ParseHost(req);
                web.Connect(host, 80);
                web.Send(Encoding.ASCII.GetBytes(req));
                byte[] response = web.Recv();
                browser.Send(response);
                ResponseBox.Text = Encoding.ASCII.GetString(response);
                RequestBox.Text = "";
                background = new Thread(BackgroundThread);
                background.IsBackground = true;
                background.Start();
            }
        }
    }
}
