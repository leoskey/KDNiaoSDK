using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDNiaoSDK.Model
{
    /// <summary>
    /// 电子面单。
    /// </summary>
    public class EOrder
    {
        /// <summary>
        /// 用户自定义回调信息。
        /// </summary>
        public string CallBack { get; set; }
        /// <summary>
        /// 会员标识，平台方与快递鸟统一用户标识的商家ID。
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 电子面单客户账号（与快递网点申请或通过快递鸟官网申请或通过申请电子面单客户号申请）。
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 电子面单密码。
        /// </summary>
        public string CustomerPwd { get; set; }
        /// <summary>
        /// 收件网点标识。
        /// </summary>
        public string SendSite { get; set; }
        /// <summary>
        /// 快递公司编码。
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 快递单号。
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 第三方订单号。
        /// </summary>
        public string ThrOrderCode { get; set; }
        /// <summary>
        /// 订单编号。
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 月结编码。
        /// </summary>
        public string MonthCode { get; set; }
        /// <summary>
        /// 邮费支付方式。
        /// </summary>
        public PayType PayType { get; set; }
        /// <summary>
        /// 快递类型。
        /// </summary>
        public string ExpType { get; set; }
        /// <summary>
        /// 是否通知快递员上门揽件。
        /// </summary>
        [JsonIgnore]
        public bool? IsNotice { get; set; }
        [JsonProperty(PropertyName = "IsNotice")]
        public string GetIsNotice
        {
            get
            {
                if (IsNotice.HasValue)
                {
                    return IsNotice.Value ? "0" : "1";
                }
                return null;
            }
        }
        /// <summary>
        /// 寄件费（运费）。
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 其他费用。
        /// </summary>
        public double OtherCost { get; set; }
        /// <summary>
        /// 收件人。
        /// </summary>
        public Receiver Receiver { get; set; }
        /// <summary>
        /// 寄件人。
        /// </summary>
        public Sender Sender { get; set; }

        private DateTime? startDate;
        /// <summary>
        /// 上门取货时间段:"yyyy-MM-dd HH:mm:ss"格式化。
        /// </summary>
        public string StartDate
        {
            get
            {
                if (startDate.HasValue)
                {
                    this.startDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return string.Empty;
            }
            set
            {
                DateTime result;
                var flag = DateTime.TryParse(value, out result);
                if (flag)
                {
                    this.startDate = result;
                }
            }
        }

        private DateTime? endDate;
        /// <summary>
        /// 上门取货时间段:"yyyy-MM-dd HH:mm:ss"格式化。
        /// </summary>
        public string EndDate
        {
            get
            {
                if (endDate.HasValue)
                {
                    this.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return string.Empty;
            }
            set
            {
                DateTime result;
                var flag = DateTime.TryParse(value, out result);
                if (flag)
                {
                    this.endDate = result;
                }
            }
        }
        /// <summary>
        /// 物品总重量kg。
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 件数/包裹数。
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 物品总体积m3。
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// 备注。
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 返回电子面单模板。
        /// </summary>
        [JsonIgnore]
        public bool? IsReturnPrintTemplate { get; set; }

        [JsonProperty(PropertyName = "IsReturnPrintTemplate")]
        public string GetIsReturnPrintTemplate
        {
            get
            {
                if (IsReturnPrintTemplate.HasValue)
                {
                    return IsReturnPrintTemplate.Value ? "1" : "0";
                }
                return null;
            }
        }
        /// <summary>
        /// 模板尺寸。
        /// </summary>
        public string TemplateSize { get; set; }

        private List<AddService> addServices { get; set; }
        /// <summary>
        /// 增值服务。
        /// </summary>
        public List<AddService> AddServices
        {
            get
            {
                return addServices;
            }
            set
            {
                this.addServices = value;
            }
        }

        private List<Commodity> commodity { get; set; }
        /// <summary>
        /// 商品。
        /// </summary>
        public List<Commodity> Commodity
        {
            get
            {
                if (commodity == null)
                {
                    commodity = new List<Commodity>();
                }
                return commodity;
            }
            set
            {
                this.commodity = value;
            }
        }

    }

    /// <summary>
    /// 邮费支付方式。
    /// </summary>
    public enum PayType
    {
        // 现付
        Now = 1,
        // 到付
        Finish = 2,
        // 月结
        Month = 3,
        // 第三方支付
        ThirdParty = 4
    }

    /// <summary>
    /// 收件地址。
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// 收件人公司。
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 收件人。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话与手机，必填一个。
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 电话与手机，必填一个。
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 收件人邮编。
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 收件省（如广东省，不要缺少“省”）。
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 收件市（如深圳市，不要缺少“市”）。
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 收件区（如福田区，不要缺少“区”或“县”）。
        /// </summary>
        public string ExpAreaName { get; set; }
        /// <summary>
        /// 收件人详细地址。
        /// </summary>
        public string Address { get; set; }

    }

    /// <summary>
    /// 寄件地址。
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// 发件人公司。
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 发件人。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话与手机，必填一个。
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 电话与手机，必填一个。
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 发件人邮编。
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 发件省（如广东省，不要缺少“省”）。
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 发件市（如深圳市，不要缺少“市”）。
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 发件区（如福田区，不要缺少“区”或“县”）。
        /// </summary>
        public string ExpAreaName { get; set; }
        /// <summary>
        /// 发件详细地址。
        /// </summary>
        public string Address { get; set; }

    }

    /// <summary>
    /// 增值服务。
    /// </summary>
    public class AddService
    {
        /// <summary>
        /// 增值服务名称。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 增值服务值。
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 客户标识(选填)。
        /// </summary>
        public string CustomerID { get; set; }

    }

    /// <summary>
    /// 商品。
    /// </summary>
    public class Commodity
    {
        /// <summary>
        /// 商品名称。
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品编码。
        /// </summary>
        public string GoodsCode { get; set; }
        /// <summary>
        /// 件数。
        /// </summary>
        public int Goodsquantity { get; set; }
        /// <summary>
        /// 商品价格。
        /// </summary>
        public double GoodsPrice { get; set; }
        /// <summary>
        /// 商品重量kg。
        /// </summary>
        public double GoodsWeight { get; set; }
        /// <summary>
        /// 商品描述。
        /// </summary>
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 商品体积m3。
        /// </summary>
        public double GoodsVol { get; set; }

    }
}
