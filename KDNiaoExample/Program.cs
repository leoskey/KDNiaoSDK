using KDNiaoSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KDNiaoSDK;

namespace KDNiaoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var eOrder = new EOrder();
            var sender = new Sender();
            sender.Name = "Taylor";
            sender.Mobile = "15018442396";
            sender.ProvinceName = "上海";
            sender.CityName = "上海";
            sender.ExpAreaName = "青浦区";
            sender.Address = "明珠路73号";
            eOrder.Sender = sender;
            var receiver = new Receiver();
            receiver.Name = "Yann";
            receiver.Mobile = "15018442396";
            receiver.ProvinceName = "北京";
            receiver.CityName = "北京";
            receiver.ExpAreaName = "朝阳区";
            receiver.Address = "三里屯街道雅秀大厦";
            eOrder.Receiver = receiver;
            var good = new Commodity();
            good.GoodsName = "鞋子";
            good.GoodsWeight = 1.0;
            eOrder.Commodity.Add(good);
            eOrder.ExpType = "1";
            eOrder.PayType = PayType.Finish;
            eOrder.ShipperCode = "YD";
            eOrder.OrderCode = "YD201703011102105952";
            eOrder.CustomerName = "testyd";
            eOrder.CustomerPwd = "testydpwd";

            var eBusinessID = "";
            var appKey = "";
            var client = new KDNiaoClient(eBusinessID, appKey);
            var result = client.AddEOrder(eOrder);

            Console.WriteLine(JsonConvert.SerializeObject(result));

        }
    }
}
