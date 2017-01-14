using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            //Query<int> ss = new Query<int>(new QueryProvider());
            //var tf = ss.Where(e => e == 123).Where(e=>e>10);
            //var t2v = tf.FirstOrDefault();
            QueryOrder<Order> sst = new QueryOrder<Order>(new QueryProvider());
            var ts = sst.Where(p => p.OrderName == "").SingleOrDefault();
            
            
        }
    }
}
