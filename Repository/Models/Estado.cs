﻿using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Estadoservicio = new HashSet<Estadoservicio>();
        }

        public sbyte Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Estadoservicio> Estadoservicio { get; set; }
    }
}
