using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Estadoservicio
    {
        public int Id { get; set; }
        public sbyte IdLinea { get; set; }
        public sbyte IdEstado { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan? HoraHasta { get; set; }
        public DateTime Fecha { get; set; }
        public sbyte? EsFeriado { get; set; }
        public string Descripcion { get; set; }

        public Estado IdEstadoNavigation { get; set; }
        public Linea IdLineaNavigation { get; set; }
    }
}
