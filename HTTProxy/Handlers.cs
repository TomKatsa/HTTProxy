﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HTTProxy
{
    interface IHandler
    {
        string Handle(string r);
    }

    class EmptyHandler : IHandler
    {
        public EmptyHandler()
        {

        }
        public string Handle(string request)
        {
            return request;
        }
    }

    class FileExtHandler: IHandler
    {
        Form1 form;
        public FileExtHandler(Form1 form)
        {
            this.form = form;
        }
        public string Handle(string request)
        {
            Match r = Regex.Match(request, @"(GET|POST)+\s.*\.(js|css|png|ico|gif)+\s");
            if (r.Success) // Match file extensions for scripts/images: js,css,png,ico
            {
                form.SendSequence(request, Form1.Action.Auto);
                return ""; // The request is done
            }
            else
            {
                return request;
            }
        }
    }

    class ConnectionHeaderHandler : IHandler
    {
        public ConnectionHeaderHandler()
        {

        }
        public string Handle(string request)
        {
            return request.Replace("Connection: keep-alive", "Connection: close");
        }
    }

    class EncodingHeaderHandler : IHandler
    {
        public EncodingHeaderHandler()
        {

        }
        public string Handle(string request)
        {

            Match r = Regex.Match(request, @"Accept-Encoding: .*\s");
            if (r.Success)
            {
                return request.Replace(r.Value, "");
            }
            return request;
        }
    }
}
