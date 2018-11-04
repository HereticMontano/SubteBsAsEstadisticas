using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;
using System;
using System.Linq;
using WebSubteEstadisticas.Helper;

namespace WebSubteEstadisticas.Controllers.Api
{
    [Route("api/DataApi")]    
    public class DataApiController : ControllerBase
    {
        private Manager manager = new Manager(new subtedataContext());

        [HttpGet]
        public JsonResult GetDataBetweens(DateTime desde, DateTime hasta)
        {
            var aux = HelperGetDataPeriod.GetBetweenDates(manager, desde, hasta);

            return new JsonResult(new
            {
                Normal = aux.Select(x => x.GetTiempoNormal).ToArray(),
                Suspendida = aux.Select(x => x.GetTiempoSuspendido).ToArray(),
                Demora = aux.Select(x => x.GetTiempoDemora).ToArray(),
                Limitada = aux.Select(x => x.GetTiempoLimitada).ToArray(),
                Anormales = aux.Select(x => x.GetTiempoAnormales).ToArray()
            });
        }
    }
}
