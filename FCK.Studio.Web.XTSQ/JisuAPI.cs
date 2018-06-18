using FCK.Studio.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ
{
    public class JisuAPI
    {
        private static string appkey = ConfigurationManager.AppSettings["JisuAPPKEY"];

        public static SmsResponse SmsSend(string mobile, string content)
        {
            string smsapi = "http://api.jisuapi.com/sms/send?mobile=" + mobile + "&content=" + content + "&appkey=" + appkey;
            SmsObj jsonData = new SmsObj();
            jsonData.appkey = appkey;
            jsonData.content = content;
            jsonData.mobile = mobile;
            string jsonStr = JsonConvert.SerializeObject(jsonData);
            string response = HttpHelper.Get(smsapi);
            return JsonConvert.DeserializeObject<SmsResponse>(response);
        }


    }

    public class SmsObj
    {
        public string mobile { get; set; }
        public string content { get; set; }
        public string appkey { get; set; }
    }

    public class SmsResponse
    {
        public int status { get; set; }
        public string msg { get; set; }
        public SmsResResult result { get; set; }
    }

    public class SmsResResult
    {
        public int count { get; set; }
        public int accountid { get; set; }
    }
}