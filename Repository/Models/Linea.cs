﻿using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Linea
    {
        public Linea()
        {
            Estadoservicio = new HashSet<Estadoservicio>();
            Itinerario = new HashSet<Itinerario>();
            Precalculado = new HashSet<Precalculado>();
        }

        public sbyte Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Estadoservicio> Estadoservicio { get; set; }
        public ICollection<Itinerario> Itinerario { get; set; }
        public ICollection<Precalculado> Precalculado { get; set; }
    }
}
