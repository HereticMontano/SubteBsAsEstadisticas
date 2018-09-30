using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;
using WebSubteEstadisticas.Helper;
using WebSubteEstadisticas.Models;

namespace WebSubteEstadisticas.Controllers
{
    public class HomeController : Controller
    {
        private Manager manager = new Manager(new subtedataContext());
        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.DatosFuncionamiento  = HelperGetDataPeriod.GetStaticLastDay(manager);         
            
            return View(model);
        }

        public IActionResult About()
        {
            var model = new HomeViewModel();

            model.DatosFuncionamiento = HelperGetDataPeriod.GetStaticLastDay(manager);

            return View(model);
        }
    }
}
