using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Tipodia
    {
        public Tipodia()
        {
            Itinerario = new HashSet<Itinerario>();
        }

        public sbyte Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Itinerario> Itinerario { get; set; }
    }
}
