using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KV.DB;
using KV.Entities.Models;
using KV.DLL;

namespace KV.Web.Controllers
{
    [Route("/[controller]/[Action]/[id]")]
    [ApiController]
    public class UserKVController : ControllerBase
    {
        [HttpGet]
        public string Index() {
            return "success";
        }
        [HttpGet]
        public Bookinfo GetBook() {
            return new DBEntity().Query<Bookinfo>().FirstOrDefault();
        }
        [HttpGet]
        public Response<Root> QueryWe(string areaName) {
            return new BLLWeather().GetWeatherByAreaName(areaName);
        }
    }
}