using Repository.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using WebSubteEstadisticas.Models.Interno;

namespace WebSubteEstadisticas.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public List<TiempoFuncionamiento> DatosFuncionamiento { get; set; }
    }
}