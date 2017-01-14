using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
 * 
 * 作者：Justin.Jia
 * 文件名称：Order
 * 创建日期：2017/1/14 21:51:17
 * 说明：详见代码内容
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 Justin.Jia 2017/1/14 21:51:17
 * 
*******************************************************/

namespace Linq2Object
{
    /// <summary> 
    /// 订单类型 
    /// </summary> 
    public class Order
    {
        /// <summary> 
        /// 订单名称 
        /// </summary> 
        public string OrderName { get; set; }
        /// <summary> 
        /// 下单时间 
        /// </summary> 
        public DateTime OrderTime { get; set; }
        /// <summary> 
        /// 订单编号 
        /// </summary> 
        public Guid OrderCode { get; set; }
    }

    public static class OrderCollectionExtent
    {
        public static bool IsValuesAdd<T>(this IEnumerable<T> IEnumberable) where T:Order
        {
            foreach (var item in IEnumberable)
            {
                if (item.OrderCode != null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }

    public class OrderCollect : IEnumerable<Order>
    {
        List<Order> orderList;

        public OrderCollect()
        {
            orderList = new List<Order>()
            {
               new Order(){ OrderCode=Guid.NewGuid(),OrderName="订单1", OrderTime=DateTime.Now},
               new Order(){ OrderCode=Guid.NewGuid(),OrderName="订单2", OrderTime=DateTime.Now},
               new Order(){ OrderCode=Guid.NewGuid(),OrderName="订单3", OrderTime=DateTime.Now}
           };
        }
        public IEnumerator<Order> GetEnumerator()
        {
            foreach (var order in orderList)
            {
                yield return order;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var order in orderList)
            {
                yield return order;
            }
        }
    }
}
