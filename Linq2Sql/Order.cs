using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
 * 
 * 作者：Justin.Jia
 * 文件名称：Order
 * 创建日期：2017/1/14 23:05:53
 * 说明：详见代码内容
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 Justin.Jia 2017/1/14 23:05:53
 * 
*******************************************************/

namespace Linq2Sql
{
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
}
