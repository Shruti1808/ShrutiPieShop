using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShrutiPieShop.Models;

namespace ShrutiPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(ICategoryRepository categoryRepository, IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //Method to return a list of Pies
        public ViewResult List()
        {
            return View(_pieRepository.Pies);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
