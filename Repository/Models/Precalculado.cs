using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Precalculado
    {
        public int Id { get; set; }
        public sbyte IdLinea { get; set; }
        public int Horas { get; set; }

        public Linea IdLineaNavigation { get; set; }
    }
}
