using Newtonsoft.Json;
using Repository;
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

        private static readonly Manager Repository = new Manager(new subtedataContext());

        public static async Task ProcessEstado()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("https://haysubte.now.sh/api");
            var lineas = AddKeysToValues(await stringTask);

            var date = DateTime.Now;
            
            var fecha = Repository.FechaestadoServicio.FirstOrDefault(x => x.Fecha == date || x.Estadoservicio.Any(y => y.HoraHasta == null));
            if (fecha == null)
            {
                fecha = new Fechaestadoservicio { Fecha = date, IdTipoDia = (sbyte)GetEnumTipoDia(date) };
                Repository.FechaestadoServicio.Add(fecha);
            }

            var ultimosEstados = fecha.Estadoservicio.Where(x => x.HoraHasta == null);          

            foreach (var item in lineas)
            {
                var idLinea = (sbyte)Enum.Parse(typeof(EnumLinea), item.Linea.ToUpper());
                var idEstado = (sbyte)Enum.Parse(typeof(EnumEstado), item.Detalle.Status.ToUpper());
                var linea = ultimosEstados.FirstOrDefault(x => x.IdLinea == idLinea);
                
                if(date.Hour != 2)
                {
                    if (idEstado != (sbyte)EnumEstado.NORMAL && linea == null)
                    {
                        AddEstado(item, idLinea, idEstado, fecha.Id);
                    }
                    else if (linea != null && linea.IdEstado != idEstado)
                    {
                        linea.HoraHasta = date.TimeOfDay;
                    }
                }
                //Si son las 2 de la mañana y todavia hay lineas en estado Suspendido se pone el horario hasta segun el itinerario  
                else if(linea != null)
                {                    
                    var itinerario = Repository.Itinerario.Where(x => x.IdLinea == idLinea && 
                                                                      x.IdTipoDia == fecha.IdTipoDia && 
                                                                      x.FechaItinerario <= fecha.Fecha).OrderByDescending(x => x.FechaItinerario).FirstOrDefault();
                    linea.HoraHasta = itinerario.HoraHasta;
                }                
            }
            
            Repository.SaveChanges();

        }

        private static void AddEstado(SubteStatus item, sbyte idLinea, sbyte idEstado, int idFecha)
        {
            var aux = new Estadoservicio
            {
                IdLinea = idLinea,
                IdEstado = idEstado,                
                HoraDesde = DateTime.Now.TimeOfDay,
                IdFecha = idFecha,
                Descripcion = item.Detalle.Text
            };
            Repository.EstadoServicio.Add(aux);
        }

        //Asigna las idkey para cada linea que viene en el json
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

        private static EnumTipoDia GetEnumTipoDia(DateTime dateDia)
        {
            switch (dateDia.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Friday:
                    return EnumTipoDia.DiaDeSemana;
                case DayOfWeek.Saturday:
                    return EnumTipoDia.Sabado;
                case DayOfWeek.Sunday:
                    return EnumTipoDia.Domingo;
                default:
                    //Es imposible que entre por aca pero en el futuro se deberia cambiar esta logica, para que valide pegandole a alguna api para saber si el dia es feriado.
                    return EnumTipoDia.Feriado;               
            }
        }
    }
    

}
