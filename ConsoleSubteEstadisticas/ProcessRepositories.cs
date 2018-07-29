using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleSubteEstadisticas
{

    public static class Process
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("https://haysubte.now.sh/api");

            AddKeysToValues(await stringTask);            

        }

        private static string AddKeysToValues(string json)
        {
            var lineas = new List<SubteStatus>();
            var routes_list = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            foreach (var item in routes_list)
            {
                var aux = new SubteStatus { Linea = item.Key };
                aux.Detalle = JsonConvert.DeserializeObject<SubteDetalle>(item.Value.ToString());
                lineas.Add(aux);
            }
            
            return "";
        }
    }
    

}
