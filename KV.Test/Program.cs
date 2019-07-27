using System;
using System.Linq;
using KV.DLL;
namespace KV.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BLLWeather we = new BLLWeather();
            we.GetWeatherByAreaName("赣州");
            Console.WriteLine("Hello World!");
        }
    }
}
