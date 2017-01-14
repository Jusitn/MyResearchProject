using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Object
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Order> orderlist = new List<Order>()
            //{
            //    new Order(){ OrderCode=Guid.NewGuid(), OrderName="水果", OrderTime=DateTime.Now},
            //    new Order(){ OrderCode=Guid.NewGuid(), OrderName="办公用品",OrderTime=DateTime.Now}
            //};
            //bool Isv= orderlist.IsValuesAdd<Order>();

            OrderCollect list = new OrderCollect();
            foreach (var iten in list)
            {
                var it= iten;
            }
        }
    }
}
