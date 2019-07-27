using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
namespace KV.DLL
{
    public static class HttpHelper
    {
        public static T Request<T>(string url,string method,string data=null,Encoding encoding=null) {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            if (method.ToLower().Equals("post"))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                Stream stream = request.GetRequestStream();
                stream.Write(buffer,0,buffer.Length);
            }
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (encoding == null) encoding = Encoding.UTF8;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                var temp= reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(temp);
            }
        }
    }
}
