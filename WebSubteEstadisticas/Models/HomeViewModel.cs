using Repository.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebSubteEstadisticas.Models
{
    public class HomeViewModel : BaseViewModel
    {
       public List<Estadoservicio> GetEstadoservicios { get; set; }
    }
}