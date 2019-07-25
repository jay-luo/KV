using System;
using System.Collections.Generic;

namespace KV.Entities.Models
{
    public partial class BarCode
    {
        public int Id { get; set; }
        public string Epc { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
