using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6M2_Patrice_Keusch
{

    public delegate void NewsHandler(object sender, NewsEventArgs args);

    class NewsTicker
    {

        public NewsTicker()
        {

        }

        public void Test()
        {
            // code...
            if (DateTime.Now.Hour == 12)
            {
                OnNews(this, new NewsEventArgs("Test"));
            }
           // code... 
        }

        public event NewsHandler News;

        protected virtual void OnNews(object sender, NewsEventArgs args)
        {

            if (News != null)
            {
                this.News(sender, args);
            }

        }


    }


    



}
