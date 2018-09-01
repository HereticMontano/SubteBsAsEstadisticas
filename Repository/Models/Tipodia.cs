using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Tipodia
    {
        public Tipodia()
        {
            Fechaestadoservicio = new HashSet<Fechaestadoservicio>();
            Itinerario = new HashSet<Itinerario>();
        }

        public sbyte Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Fechaestadoservicio> Fechaestadoservicio { get; set; }
        public ICollection<Itinerario> Itinerario { get; set; }
    }
}
