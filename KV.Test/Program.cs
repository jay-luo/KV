using System;
using System.Linq;
using System.Text.RegularExpressions;
using KV.DLL;
using System.Collections.Generic;
namespace KV.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dd = new Dictionary<string, string>();
            dd.Add("a","1");
            dd.Add("b", "2");
            var ss= dd.FirstOrDefault(x => x.Key == "asas");
            var v = ss.Value;
            string a = "asd(12345)";
            var version = Regex.Replace(a, @"asd(.*\()(.*)(\).*)", "$2");
        }
    }
}
