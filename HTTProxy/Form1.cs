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
        private BrowserConnection browser;
        private WebConnection web;
        private IHandler file_ext_handle;
        private byte[] request_bytes;

        public enum Sender
        {
            User, Handler
        }

        public Form1()
        {
            web = new WebConnection(); // Connecting to web server
            browser = new BrowserConnection("127.0.0.1", 8080); // Connecting to local browser
            file_ext_handle = new FileExtHandler(this); // Handling file extension in request, to automatically receive images.
            background = new Thread(BackgroundThread); // To receive requests from browser and not block the UI
            background.IsBackground = true;
            background.Start();
            InitializeComponent();
        }


        public void BackgroundThread()
        {
            string request = "";
            browser.Accept();
            request_bytes = browser.Recv();
            request = Encoding.ASCII.GetString(request_bytes);
            request = file_ext_handle.Handle(request);
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
                SendSequence(req, Sender.User);
            }
        }

        private void SkipBtn_Click(object sender, EventArgs e)
        {
            string req = RequestBox.Text;
            if (!background.IsAlive || req != "") // Checking if not waiting for new request and request isn't empty
            {
                SendSequence("", Sender.Handler); // Sending empty request
            }

        }


        private void RestartThread()
        {
            background = new Thread(BackgroundThread);
            background.IsBackground = true;
            background.Start();
        }


        public void SendSequence(string msg, Sender sender)
        {
            string host = WebConnection.ParseHost(msg);
            WriteRequest("");
            if (sender==Sender.User)
                WriteResponse(""); // If the user requested, clear first the response
            if (host == "")
            {
                RestartThread(); // Invalid host
                return;
            }
            if (msg=="")
            {
                browser.Send(ASCIIEncoding.ASCII.GetBytes("Request skipped.")); // The skip button
                RestartThread();
                return;
            }
            try
            {
                web.Connect(host, 80);
                web.Send(Encoding.ASCII.GetBytes(msg));
                byte[] response = web.Recv();
                if (sender==Sender.User)
                {
                    WriteResponse(Encoding.ASCII.GetString(response)); // If user made the request, update the response box
                    // If the Handler made the request, leave the response box
                }

                browser.Send(response); // Receiving response in the browser
            }
            catch (Exception ex) {
                WriteResponse(DateTime.Now.ToString("MM/dd/yyyy HH:mm") + " Exception: " + ex.Message);
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
    }
}
