using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Fechaestadoservicio
    {
        public Fechaestadoservicio()
        {
            Estadoservicio = new HashSet<Estadoservicio>();
            Precalculado = new HashSet<Precalculado>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public sbyte IdTipoDia { get; set; }

        public Tipodia IdTipoDiaNavigation { get; set; }
        public virtual ICollection<Estadoservicio> Estadoservicio { get; set; }
        public ICollection<Precalculado> Precalculado { get; set; }
    }
}
