using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6M2_Patrice_Keusch
{
    class Program
    {
        static void Main(string[] args)
        {
            NewsTicker ticker = new NewsTicker();
            ticker.News += tickerNews;
            ticker.Test();
        }

        static void tickerNews(object sender, NewsEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
