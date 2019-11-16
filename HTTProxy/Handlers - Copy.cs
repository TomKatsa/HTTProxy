using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HTTProxy
{
    class Handler
    {
        private Handler h;
        public Handler()
        {

        }

        public Handler(Handler h)
        {
            this.h = h;
        }
        public virtual string Handle(string request)
        {
            return request;
        }
    }

    class FileExtHandler : Handler
    {
        private Handler h;
        public FileExtHandler(Handler h)
        {
            this.h = h;
        }
        public FileExtHandler()
        {
            this.h = new Handler();
        }
        public override string Handle(string request)
        {
            Match file_ext = Regex.Match(request, @"[(GET)(POST)] .*\.[(css)(js)(png)]");
            if (file_ext.Success)
            {
                MessageBox.Show("Matched: " + file_ext.ToString());
            }
            return h.Handle(request);
        }
    }
}
