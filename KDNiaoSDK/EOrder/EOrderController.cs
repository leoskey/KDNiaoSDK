using KDNiaoSDK.Common;
using KDNiaoSDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KDNiaoSDK
{
    /// <summary>
    /// 电子面单。
    /// </summary>
    public class EOrderController
    {

        /// <summary>
        /// 请求参数。
        /// </summary>
        private RequestParameter _RequestParameter { get; set; }
        private string _ApiUrl { get; set; }
        private string _AppKey { get; set; }

        public EOrderController(string eBusinessID, string appKey, string url)
        {
            _RequestParameter = new RequestParameter();
            this._RequestParameter.EBusinessID = eBusinessID;
            this._RequestParameter.DataType = "2";
            this._RequestParameter.RequestType = "1007";
            this._ApiUrl = url;
            this._AppKey = appKey;
        }

        /// <summary>
        /// 下单。
        /// </summary>
        /// <returns></returns>
        public EOrderResult PlaceAnOrder(EOrder eOrder)
        {
            return new HttpHandler(HTTPMethod.POST, this._ApiUrl, ConvertToPOSTFormat(eOrder)).GetResponse<EOrderResult>();
        }

        /// <summary>
        /// 格式化为快递鸟指定格式。
        /// </summary>
        /// <param name="eOrder"></param>
        /// <returns></returns>
        private string ConvertToPOSTFormat(EOrder eOrder)
        {
            var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            this._RequestParameter.RequestData = JsonConvert.SerializeObject(eOrder, Formatting.None, jSetting);
            this._RequestParameter.DataSign = GetDataSign(this._RequestParameter.RequestData + this._AppKey);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(this._RequestParameter.RequestData));
            param.Add("EBusinessID", this._RequestParameter.EBusinessID);
            param.Add("RequestType", this._RequestParameter.RequestType);
            param.Add("DataSign", this._RequestParameter.DataSign);
            param.Add("DataType", this._RequestParameter.DataType);
            StringBuilder result = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                foreach (var p in param)
                {
                    if (result.Length > 0)
                    {
                        result.Append("&");
                    }
                    result.Append(p.Key);
                    result.Append("=");
                    result.Append(p.Value);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 获取DataSign。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetDataSign(string str)
        {
            var md5Str = GetMD5(str);
            return HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(md5Str.ToLower())), Encoding.UTF8);
        }

        /// <summary>
        /// 获取字符串的MD5值。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetMD5(string str)
        {
            var result = "";
            byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes(str);
            try
            {
                var check = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] somme = check.ComputeHash(buffer);
                foreach (byte a in somme)
                {
                    if (a < 16)
                        result += "0" + a.ToString("X");
                    else
                        result += a.ToString("X");
                }
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
    }

}
