using Newtonsoft.Json;
using Repository.Enum;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleSubteEstadisticas
{

    public static class ProcessEstadoSubte
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly SubtedataContext Repository = new SubtedataContext();

        public static async Task ProcessEstado()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("https://haysubte.now.sh/api");

            var lineas = AddKeysToValues(await stringTask);

            var lastLog = Repository.Estadoservicio.Where(x => x.FechaHasta == null);

            foreach (var item in lineas)
            {
                var idLinea = (sbyte)Enum.Parse(typeof(EnumLinea), item.Linea.ToUpper());
                var idEstado = (sbyte)Enum.Parse(typeof(EnumEstado), item.Detalle.Status.ToUpper());
                var linea = lastLog.FirstOrDefault(x => x.IdLinea == idLinea);
                if (linea == null )
                {
                    AddEstado(item, idLinea, idEstado);
                }
                else if(linea.IdEstado != idEstado)
                {
                    linea.FechaHasta = DateTime.UtcNow;
                    AddEstado(item, idLinea, idEstado);
                }
            }

            Repository.SaveChanges();
        }

        private static void AddEstado(SubteStatus item, sbyte idLinea, sbyte idEstado)
        {
            var aux = new Estadoservicio
            {
                IdLinea = idLinea,
                IdEstado = idEstado,
                FechaDesde = DateTime.UtcNow,
                Descripcion = item.Detalle.Text
            };
            Repository.Estadoservicio.Add(aux);
        }

        private static List<SubteStatus> AddKeysToValues(string json)
        {
            var lineas = new List<SubteStatus>();
            var routes_list = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            foreach (var item in routes_list)
            {
                var aux = new SubteStatus { Linea = item.Key };
                aux.Detalle = JsonConvert.DeserializeObject<SubteDetalle>(item.Value.ToString());
                lineas.Add(aux);
            }
            
            return lineas;
        }
    }
    

}
