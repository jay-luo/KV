using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KV.DB;
using KV.Entities;
using KV.Entities.Models;

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
        public Bookinfo GetBook() {
            return new DBEntity().Query<Bookinfo>().FirstOrDefault();
        }
    }
}