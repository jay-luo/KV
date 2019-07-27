using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using KV.DB;
using KV.Entities.Models;

namespace KV.DLL
{
    public class BLLWeather
    {
        public static List<city> cylist = new List<city>();
        public BLLWeather() {
            if (cylist==null || cylist.Count<=0) {
                InitLoad();
            }
        }
        private void InitLoad() {
            string path = Environment.CurrentDirectory + "/Source/" + "_city.json";
            FileStream stream = new FileStream(path,FileMode.Open,FileAccess.Read);
            using (StreamReader reader=new StreamReader(stream, Encoding.UTF8))
            {
                var a = reader.ReadToEnd();
                cylist= JsonConvert.DeserializeObject<List<city>>(a);
            }
        }
        public Response<Root> GetWeatherByAreaName(string areaName) {
            var db = new DBEntity();
            var ct = cylist.FirstOrDefault(x => x.city_name == areaName);
            if (ct == null) return new Response<Root>() {Code=-1,Message="该城市暂未收录进系统" };
            if (string.IsNullOrEmpty(ct.city_code)) return new Response<Root>() {Code=-1,Message="查询范围过大,请缩小查询区域" };
            var we = db.Query<DateWeather>().FirstOrDefault(x => x.DailyDate == DateTime.Now.Date && x.CityCode == ct.city_code);
            if (we == null) {
                string url = string.Format("http://t.weather.sojson.com/api/weather/city/{0}", ct.city_code);
                var root =HttpHelper.Request<Root>(url,"get");
                if (root.status == 200) {
                    InsertWeather(ct.city_code, JsonConvert.SerializeObject(root));
                }
                return new Response<Root>() { Code = 0, Data = root };
            }
            else
            {
                return new Response<Root>() {Code=0,Data=JsonConvert.DeserializeObject<Root>(we.Body) };
            }
        }
        public void InsertWeather(string cityCode,string body) {
            DBEntity db = new DBEntity();
            DateWeather we = new DateWeather();
            we.Body = body;
            we.CityCode = cityCode;
            we.DailyDate = DateTime.Now.Date;
            we.CreateTime = DateTime.Now;
            db.Insert(we);
            db.SaveChanges();
        }
    }
    public class city {
        public int id { get; set; }
        public int pid { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string area_code { get; set; }
    }
    public class CityInfo
    {
        /// <summary>
        /// 赣州市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string citykey { get; set; }
        /// <summary>
        /// 江西
        /// </summary>
        public string parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
    }

    public class ForecastItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 高温 36℃
        /// </summary>
        public string high { get; set; }
        /// <summary>
        /// 低温 27℃
        /// </summary>
        public string low { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ymd { get; set; }
        /// <summary>
        /// 星期六
        /// </summary>
        public string week { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sunrise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sunset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int aqi { get; set; }
        /// <summary>
        /// 南风
        /// </summary>
        public string fx { get; set; }
        /// <summary>
        /// 3-4级
        /// </summary>
        public string fl { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 阴晴之间，谨防紫外线侵扰
        /// </summary>
        public string notice { get; set; }
    }

    public class Yesterday
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 高温 36℃
        /// </summary>
        public string high { get; set; }
        /// <summary>
        /// 低温 27℃
        /// </summary>
        public string low { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ymd { get; set; }
        /// <summary>
        /// 星期五
        /// </summary>
        public string week { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sunrise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sunset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int aqi { get; set; }
        /// <summary>
        /// 西南风
        /// </summary>
        public string fx { get; set; }
        /// <summary>
        /// <3级
        /// </summary>
        public string fl { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 阴晴之间，谨防紫外线侵扰
        /// </summary>
        public string notice { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string shidu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pm25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pm10 { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wendu { get; set; }
        /// <summary>
        /// 各类人群可自由活动
        /// </summary>
        public string ganmao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ForecastItem> forecast { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Yesterday yesterday { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// success感谢又拍云(upyun.com)提供CDN赞助
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CityInfo cityInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

}
