using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnowBoardMarket.Extentions;
using SnowBoardMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowBoardMarket.Controllers
{
    public class HomeController : Controller
    {
        private AppSettings AppSettings { get; set; }

        public HomeController(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}
