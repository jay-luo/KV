using System;
using System.Collections.Generic;

namespace KV.Entities.Models
{
    public partial class Bookinfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Remark { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public string Publisher { get; set; }
        public string Pagecount { get; set; }
        public string Booksize { get; set; }
        public string CategoryNum { get; set; }
        public DateTime Createtime { get; set; }
        public string Limg { get; set; }
        public string Mimg { get; set; }
        public string Simg { get; set; }
        public string Translation { get; set; }
        public DateTime? Publishdate { get; set; }
        public int? BNo { get; set; }
    }
}
