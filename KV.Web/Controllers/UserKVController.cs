using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KV.DB;
using KV.Entities.Models;
using KV.DLL;
using log4net;
using log4net.Config;
using log4net.Repository;
using System.IO;

namespace KV.Web.Controllers
{
    [Route("/[controller]/[Action]")]
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
        public async Task<Response<Root>> QueryWe(string areaName) {
            var ip= Request.Host;
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4g.xml"));
            ILog log = LogManager.GetLogger(repository.Name, "ConsoleAppender");

            log.Info("==========================");
            log.Info("这里记录日志");
            log.Info("==========================");
            var rst = await Task.Run(()=>new BLLWeather().GetWeatherByAreaName(areaName));
            return rst;
        }
    }
}