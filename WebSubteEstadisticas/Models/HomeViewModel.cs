using Repository.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebSubteEstadisticas.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            GetNumeros = new List<int>();
        }
        public List<Estadoservicio> GetEstadoservicios { get; set; }
        public List<int> GetNumeros { get; set; }
    }
}