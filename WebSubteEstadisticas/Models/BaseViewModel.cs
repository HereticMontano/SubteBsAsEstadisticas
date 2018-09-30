using System;
using System.Collections.Generic;

namespace WebSubteEstadisticas.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Title = "Estadisticas subte";
        }

        public string Title { get; set; }
    }
}