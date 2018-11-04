using Microsoft.AspNetCore.Mvc;
using WebSubteEstadisticas.Models;

namespace WebSubteEstadisticas.Controllers
{
    public class HomeController : Controller
    {     
        public IActionResult Index()
        {
            var model = new HomeViewModel();          
            
            return View(model);
        }

        public IActionResult About()
        {
            var model = new HomeViewModel();         

            return View(model);
        }
    }
}
