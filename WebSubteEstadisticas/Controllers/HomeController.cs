using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;
using System.Linq;
using WebSubteEstadisticas.Models;

namespace WebSubteEstadisticas.Controllers
{
    public class HomeController : Controller
    {
        private Manager manager = new Manager(new subtedataContext());
        public IActionResult Index()
        {
            var model = new HomeViewModel() { Title = "Esa papa!" };

            model.GetEstadoservicios = manager.Estadoservicio.ToList();

            model.GetNumeros.AddRange(new int[] { 12, 19, 3, 5, 2, 3 });

            
            return View(model);
        }     
    }
}
