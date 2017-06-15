using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDNiaoSDK.Model
{
    /// <summary>
    /// 电子面单，服务器返回数据。
    /// </summary>
    public class EOrderResult
    {
        /// <summary>
        /// 用户ID。
        /// </summary>
        public string EBusinessID { get; set; }
        /// <summary>
        /// 电子面单信息。
        /// </summary>
        public class Order
        {
            /// <summary>
            /// 订单编号。
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 快递公司编码。
            /// </summary>
            public string ShipperCode { get; set; }
            /// <summary>
            /// 快递单号。
            /// </summary>
            public string LogisticCode { get; set; }
            /// <summary>
            /// 大头笔。
            /// </summary>
            public string MarkDestination { get; set; }
            /// <summary>
            /// 始发地区域编码。
            /// </summary>
            public string OriginCode { get; set; }
            /// <summary>
            /// 始发地/始发网点。
            /// </summary>
            public string OriginName { get; set; }
            /// <summary>
            /// 目的地区域编码。
            /// </summary>
            public string DestinatioCode { get; set; }
            /// <summary>
            /// 目的地/到达网点。
            /// </summary>
            public string DestinatioName { get; set; }
            /// <summary>
            /// 分拣编码。
            /// </summary>
            public string SortingCode { get; set; }
            /// <summary>
            /// 集包编码。
            /// </summary>
            public string PackageCode { get; set; }
        }
        /// <summary>
        /// 成功与否。
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 错误编码。
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        /// 失败原因。
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 唯一标识。
        /// </summary>
        public string UniquerRequestNumber { get; set; }
        /// <summary>
        /// 面单打印模板。
        /// </summary>
        public string PrintTemplate { get; set; }
        /// <summary>
        /// 订单预计到货时间yyyy-mm-dd。
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }
        /// <summary>
        /// 用户自定义回调信息。
        /// </summary>
        public string Callback { get; set; }
        /// <summary>
        /// 子单数量。
        /// </summary>
        public int SubCount { get; set; }
        /// <summary>
        /// 子单号。
        /// </summary>
        public List<string> SubOrders { get; set; }
        /// <summary>
        /// 子单模板。
        /// </summary>
        public string SubPrintTemplates { get; set; }
        /// <summary>
        /// 收件人安全电话。
        /// </summary>
        public string ReceiverSafePhone { get; set; }
        /// <summary>
        /// 寄件人安全电话。
        /// </summary>
        public string SenderSafePhone { get; set; }
        /// <summary>
        /// 拨号页面网址（转换成二维码可扫描拨号）。
        /// </summary>
        public string DialPage { get; set; }
    }
}
