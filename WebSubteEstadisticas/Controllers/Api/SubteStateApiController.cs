using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Repository.Common;
using System.Collections.Generic;
using System.Linq;

namespace WebSubteEstadisticas.Controllers.Api
{
    [Route("api/SubteStateApi")]    
    public class SubteStateApiController : ControllerBase
    {      

        [HttpGet]
        public JsonResult GetSubteState()
        {
            List<SubteStatus> ret = new List<SubteStatus>();

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = htmlWeb.Load("https://www.metrovias.com.ar");
            var tr = doc.DocumentNode.SelectNodes("//table[@class='table']/tbody/tr");

            foreach (var row in tr)
            {
                var cells = row.SelectNodes("./td");
                //Solo proceso los nodos TR que tiene 3 elementos TD, porque son las rows que me interesan en la tabla de estado
                if (cells.Count == 3)
                {
                    var status = new SubteStatus
                    {
                        //Solo me interesa la letra de la linea
                        Linea = cells[1].InnerText.Split(' ').Last(),
                        //Como el tag puede tener N clases solo me fijo que tenga una de las dos que me interesa si esta suspendido o normal
                        Status = (cells[2].GetClasses().First(x => x == "suspendido" || x == "normal")),
                        Text = HtmlEntity.DeEntitize(cells[2].SelectNodes("./div/span").Last().InnerText)
                    };
                    ret.Add(status);

                    //Si es la ultima linea de subte (no quiero incluir premetro y variantes) que termine de iterar
                    if (status.Linea == "H")
                        break;
                }
                
            }
            return new JsonResult(ret);
        }
    }
}
