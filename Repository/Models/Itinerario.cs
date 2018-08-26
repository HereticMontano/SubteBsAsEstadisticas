using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Itinerario
    {
        public int Id { get; set; }
        public sbyte IdLinea { get; set; }
        public sbyte IdTipoDia { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public DateTime FechaItinerario { get; set; }

        public Linea IdLineaNavigation { get; set; }
        public Tipodia IdTipoDiaNavigation { get; set; }
    }
}
