using System;
using System.Collections.Generic;

namespace WebSubteEstadisticas.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Info = new List<string>();
        }

        public string Title { get; set; }

        public List<string> Info { get; set; }
    }
}