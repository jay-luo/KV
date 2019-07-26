using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace KV.DLL
{
    public class BLLWeather
    {
        public static List<city> cylist = new List<city>();
        public BLLWeather() {
            if (cylist.Count <= 0) {
                InitLoad();
            }
        }
        private void InitLoad() {
            string path = Environment.CurrentDirectory+"/Source/"+ "_city.json";
            FileStream stream = new FileStream(path,FileMode.Open,FileAccess.Read);
            List<city> cylist = null;
            using (StreamReader reader=new StreamReader(stream, Encoding.UTF8))
            {
                var a = reader.ReadToEnd();
                cylist= JsonConvert.DeserializeObject<List<city>>(a);
            }
        }
    }
    public class city {
        public int id { get; set; }
        public int pid { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string area_code { get; set; }
    }
}
