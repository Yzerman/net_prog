using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6M2_Patrice_Keusch
{
    public class NewsEventArgs : EventArgs
    {

        public string Text { get; set; }
        

        public NewsEventArgs(string Text)
        {
            this.Text = Text;
        }

 


    }
}
