using KV.DB;
using KV.Entities.Models;
using System;
using System.Linq;
using KV.DLL;
namespace KV.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BLLWeather bw = new BLLWeather();
            DBEntity db = new DBEntity();
            var bk= db.Query<Bookinfo>().ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
