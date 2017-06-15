using KDNiaoSDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KDNiaoSDK.Common
{
    partial class HttpHandler
    {
        private Uri _APIUrl { get; set; }
        private string _PostData { get; set; }
        private HTTPMethod _Method { get; set; }

        public HttpHandler(HTTPMethod method, string url, string param)
        {
            this._APIUrl = new Uri(url);
            this._Method = method;
            this._PostData = param;
        }

        public T GetResponse<T>() where T : class
        {
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(this._PostData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this._APIUrl);
            request.Method = this._Method.ToString();
            request.Referer = this._APIUrl.ToString();
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 30 * 1000;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<T>(responseStream.ReadToEnd());
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

    }

    public enum HTTPMethod
    {
        Get,
        POST
    }
}
