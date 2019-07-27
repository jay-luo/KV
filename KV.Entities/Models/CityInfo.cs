using System;
using System.Collections.Generic;

namespace KV.Entities.Models
{
    public partial class CityInfo
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }
        public string AreaCode { get; set; }
    }
}
