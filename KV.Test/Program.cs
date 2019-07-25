using KV.DB;
using KV.Entities.Models;
using System;
using System.Linq;
namespace KV.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DBEntity db = new DBEntity();
            var bk= db.Query<Bookinfo>().ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
