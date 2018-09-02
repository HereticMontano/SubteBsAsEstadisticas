using System;

namespace WebSubteEstadisticas.Models.Interno
{
    public class TiempoFuncionamiento
    {
        private int _minutosNormales;
        private int _minutosSuspendos;

        public TiempoFuncionamiento(int minutosNormales, int minutosSuspendidos)
        {
            _minutosNormales = minutosNormales;
            _minutosSuspendos = minutosSuspendidos;
        }

        public double GetHorasYMinutosNormales
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(_minutosNormales).TotalHours, 2);
            }
        }

        public double GetHorasYMinutosSuspendido
        {
            get
            {
                return Math.Round(TimeSpan.FromMinutes(_minutosSuspendos).TotalHours, 2);
            }
        }
    }
}
