using Newtonsoft.Json;
using Repository.Enum;
using Repository.Models;
using System;
using System.Collections.Generic;
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

            foreach (var item in lineas)
            {
                var aux = new Estadoservicio
                {
                    IdLinea = (sbyte)Enum.Parse(typeof(EnumLinea), item.Linea.ToUpper()),
                    IdEstado = (sbyte)Enum.Parse(typeof(EnumEstado), item.Detalle.Status.ToUpper()),
                    FechaDesde = DateTime.UtcNow,
                    Descripcion = item.Detalle.Text
                };
                Repository.Estadoservicio.Add(aux);
            }

            Repository.SaveChanges();
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
