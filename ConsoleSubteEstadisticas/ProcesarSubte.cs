using Newtonsoft.Json;
using Repository;
using Repository.Enum;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleSubteEstadisticas
{

    public static class ProcesarSubte
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly Manager Repository = new Manager(new subtedataContext());

        public static async Task ProcesarLineas()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("https://haysubte.now.sh/api");
            var lineas = AddKeysToValues(await stringTask);

            ProcesarEstados(lineas);

            Repository.SaveChanges();

        }

        private static void ProcesarEstados(List<SubteStatus> lineas)
        {
            var date = DateTime.Now;
            var fecha = Repository.FechaestadoServicio.FirstOrDefault(x => x.Fecha.ToShortDateString() == date.ToShortDateString() ||
                                                                           x.Estadoservicio.Any(y => y.HoraHasta == null));
            if (fecha == null)
            {
                fecha = new Fechaestadoservicio { Fecha = date, IdTipoDia = (sbyte)GetEnumTipoDia(date) };
                Repository.FechaestadoServicio.Add(fecha);
            }

            var ultimosEstados = Repository.EstadoServicio.Where(x => x.IdFecha == fecha.Id && x.HoraHasta == null);

            foreach (var item in lineas)
            {
                var idLinea = (sbyte)Enum.Parse<EnumLinea>(item.Linea.ToUpper());
                sbyte idEstado = (sbyte)GetEstado(item);
                var linea = ultimosEstados.FirstOrDefault(x => x.IdLinea == idLinea);

                //Se obitiene el itinerario de la linea, segun el tipo de dia y la fecha mas proxima a la de hoy (toma el itinerario mas nuevo de haber habido un cambio de horarios de funcionamiento)
                var itinerario = Repository.Itinerario.Where(x => x.IdLinea == idLinea &&
                                                                    x.IdTipoDia == fecha.IdTipoDia &&
                                                                    x.FechaItinerario <= fecha.Fecha).OrderByDescending(x => x.FechaItinerario).FirstOrDefault();

                if (date.TimeOfDay >= itinerario.HoraDesde && date.TimeOfDay <= itinerario.HoraHasta)
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
                //Si la linea temrino su recorrido segun su itinerari y todavia esta en estado distinto a Normal se pone "horario hasta" segun el itinerario  
                else if (linea != null)
                {
                    linea.HoraHasta = itinerario.HoraHasta;
                }
            }
        }

        private static EnumEstado GetEstado(SubteStatus item)
        {            
            if (EsEstadoSuspendido(item))
            {
                if (item.Detalle.Text.IndexOf("demora", StringComparison.OrdinalIgnoreCase) != -1)
                    return EnumEstado.DEMORA;
                else if (item.Detalle.Text.IndexOf("limitado", StringComparison.OrdinalIgnoreCase) != -1 || item.Detalle.Text.IndexOf("no se detienen", StringComparison.OrdinalIgnoreCase) != -1)
                    return EnumEstado.LIMITADA;
                else
                    return EnumEstado.SUSPENDIDO;
            }
            return EnumEstado.NORMAL;
        }

        private static bool EsEstadoSuspendido(SubteStatus item)
        {
            // El item puede venir en estado suspendido, pero la descripcion del estado explica que la linea esta tecnicamente normal.
            return Enum.Parse<EnumEstado>(item.Detalle.Status, true) == EnumEstado.SUSPENDIDO &&
                    item.Detalle.Text.IndexOf("ya se detienen", StringComparison.OrdinalIgnoreCase) == -1 &&
                    item.Detalle.Text.IndexOf("ya realiza", StringComparison.OrdinalIgnoreCase) == -1;
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
