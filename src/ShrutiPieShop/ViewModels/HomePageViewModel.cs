using ShrutiPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShrutiPieShop.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
