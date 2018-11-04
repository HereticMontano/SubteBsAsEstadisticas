using Repository.Models;
using System;

namespace WebSubteEstadisticas.Models.Interno
{
    public class TiempoFuncionamiento
    {    
        private Precalculado Precalculo;

        public TiempoFuncionamiento(int minutosNormales, int minutosSuspendidos)
        {
          
        }

        public TiempoFuncionamiento(Precalculado datos)
        {            
            Precalculo = datos;
        }

        public double GetTiempoNormal
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(Precalculo.MinutosNormal).TotalHours, 2);
            }
        }

        public double GetTiempoSuspendido
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(Precalculo.MinutosSuspendida).TotalHours, 2);
            }
        }

        public double GetTiempoLimitada
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(Precalculo.MinutosLimitada).TotalHours, 2);
            }
        }

        public double GetTiempoDemora
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(Precalculo.MinutosDemora).TotalHours, 2);
            }
        }

        public double GetTiempoAnormales
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(Precalculo.MinutosSuspendida + Precalculo.MinutosLimitada + Precalculo.MinutosDemora).TotalHours, 2);
            }
        }
    }
}
