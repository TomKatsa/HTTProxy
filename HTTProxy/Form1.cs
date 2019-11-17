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
        static string IP = "127.0.0.1";
        static int PORT = 8080;

        Thread background;
        BrowserConnection browser;
        WebConnection web;

        List<IHandler> handlers;
        IHandler file_ext_handle;
        IHandler connection_header_handle;
        //private byte[] request_bytes;

        public enum Action
        {
            User, Auto, Skip
        }

        public Form1()
        {

            connection_header_handle = new ConnectionHeaderHandler(); // Changing the connection header to close
            file_ext_handle = new FileExtHandler(this); // Handling file extension in request, to automatically receive images.
            handlers = new List<IHandler> { file_ext_handle, connection_header_handle };

            web = new WebConnection(); // Connecting to web server
            browser = new BrowserConnection(IP, PORT); // Connecting to local browser
            
            background = new Thread(BackgroundThread); // To receive requests from browser and not block the UI
            background.IsBackground = true;
            background.Start();

            InitializeComponent();
            portLabel.Text += PORT;
        }

        public string HandleRequest(string req)
        {
            string result = "";
            foreach(IHandler handler in handlers)
            {
                result = handler.Handle(req);
                if (result == "") break;
            }
            return result;
        }


        public void BackgroundThread()
        {
            browser.Accept();
            //request_bytes = browser.Recv();
            string request = Encoding.ASCII.GetString(browser.Recv());
            request = HandleRequest(request);
            WriteRequest(request);
        }
        public void WriteRequest(string text) // Thread-safe writing to the Request TextBox
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

        public void WriteResponse(string text) // Thread-safe writing to the Response TextBox
        {
            if (ResponseBox.InvokeRequired)
            {
                ResponseBox.Invoke((MethodInvoker)(() =>
               ResponseBox.Text = text
                ));
            }
            else
            {
                ResponseBox.Text = text;
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string req = RequestBox.Text;
            if (!background.IsAlive || req != "") // Checking if not waiting for new request and request isn't empty
            {
                SendSequence(req, Action.User);
            }
        }

        private void SkipBtn_Click(object sender, EventArgs e)
        {
            string req = RequestBox.Text;
            if (!background.IsAlive || req != "") // Checking if not waiting for new request and request isn't empty
            {
                SendSequence(req, Action.Skip);
            }

        }


        private void RestartThread()
        {
            background = new Thread(BackgroundThread);
            background.IsBackground = true;
            background.Start();
        }


        public void SendSequence(string msg, Action action)
        {
            string host = WebConnection.ParseHost(msg);
            WriteRequest("");
            if (host == "")
            {
                RestartThread(); // Invalid host
                return;
            }
            if (action==Action.Skip)
            {
                browser.Send(ASCIIEncoding.ASCII.GetBytes(BrowserConnection.Skipped)); // The skip button
                RestartThread();
                return;
            }
            try
            {
                web.Connect(host, 80);
                if (web.Failed)
                {
                    throw new Exception("Couldn't connect to host.");
                }
                web.Send(Encoding.ASCII.GetBytes(msg));
                byte[] response = web.Recv();
                if (action==Action.User)
                {
                    WriteResponse(Encoding.ASCII.GetString(response)); // If user made the request, update the response box
                    // If the Handler made the request, leave the response box
                }

                browser.Send(response); // Receiving response in the browser
            }
            catch (Exception ex) {
                if (action==Action.User) // If the user request failed, print an exception.
                {
                    WriteResponse(DateTime.Now.ToString("MM/dd/yyyy HH:mm") + " " + ex.GetType().ToString() + " " + ex.Message);
                }
                
            }


            RestartThread();
        }

        private void FileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileCheckBox.Checked)
            {
                file_ext_handle = new FileExtHandler(this); // Automatically receive images/scripts
            }
            else
            {
                file_ext_handle = new EmptyHandler(); // Don't automatically receive images/scripts
                
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
