using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Precalculado
    {
        public int Id { get; set; }
        public sbyte IdLinea { get; set; }
        public int MinutosNormal { get; set; }
        public int MinutosSuspendida { get; set; }
        public int MinutosDemora { get; set; }
        public int MinutosLimitada { get; set; }
        public int IdFecha { get; set; }

        public Fechaestadoservicio IdFechaNavigation { get; set; }
        public Linea IdLineaNavigation { get; set; }
    }
}
