using KDNiaoSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDNiaoSDK
{
    public class KDNiaoClient
    {
        private string _EBusinessID { get; set; }
        private string _AppKey { get; set; }
        private string _APIUrl = "http://testapi.kdniao.cc:8081/api/EOrderService";
        //private string _APIUrl = "http://api.kdniao.cc/api/EOrderService";

        public KDNiaoClient(string eBusinessID, string appKey)
        {
            this._EBusinessID = eBusinessID;
            this._AppKey = appKey;
        }

        /// <summary>
        /// 申请电子面单。
        /// </summary>
        /// <returns></returns>
        public EOrderResult AddEOrder(EOrder eOrder)
        {
            return new EOrderController(this._EBusinessID, this._AppKey, this._APIUrl).PlaceAnOrder(eOrder);
        }
    }
}
