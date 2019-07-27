using System;
using System.Collections.Generic;

namespace KV.Entities.Models
{
    public partial class DateWeather
    {
        public int Id { get; set; }
        public string CityCode { get; set; }
        public string Body { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime DailyDate { get; set; }
    }
}
