using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;
using WebSubteEstadisticas.Models;

namespace WebSubteEstadisticas.Controllers
{
    public class HomeController : Controller
    {
        private Manager manager = new Manager(new SubtedataContext());
        public IActionResult Index()
        {
            var model = new BaseViewModel() { Title = "Esa papa!" };

            foreach (var item in manager.Estadoservicio)
            {
                model.Info.Add(string.Format("linea: {0}  el estado: {1}  el Id:{2}", manager.Linea.Find(item.IdLinea).Descripcion, item.Descripcion, item.Id));
            } 

            
            return View(model);
        }     
    }
}
