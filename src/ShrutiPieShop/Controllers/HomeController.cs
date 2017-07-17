using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShrutiPieShop.Models;
using ShrutiPieShop.ViewModels;

namespace ShrutiPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var homePageViewModel = new HomePageViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };
            return View(homePageViewModel);
        }
    }
}
