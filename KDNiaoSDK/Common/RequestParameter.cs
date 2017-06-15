using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDNiaoSDK.Common
{
    /// <summary>
    /// HTTP请求参数。
    /// </summary>
    public class RequestParameter
    {
        public string RequestData { get; set; }
        public string EBusinessID { get; set; }
        public string RequestType { get; set; }
        public string DataSign { get; set; }
        public string DataType { get; set; }

    }
}
