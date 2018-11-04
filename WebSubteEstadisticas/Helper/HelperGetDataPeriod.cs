using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSubteEstadisticas.Models.Interno;

namespace WebSubteEstadisticas.Helper
{
    public static class HelperGetDataPeriod
    {
        public static List<TiempoFuncionamiento> GetStaticLastDay(Manager manager)
        {
            var ret = new List<TiempoFuncionamiento>();
            var fechaEstado = manager.FechaestadoServicio.LastOrDefault(x => x.Fecha <= DateTime.Now.AddDays(-1));
            
            if (fechaEstado != null)
            {
                var lineasPrecalculadas = manager.Precalculados.Where(x => x.IdFecha == fechaEstado.Id);

                foreach (var item in lineasPrecalculadas)
                {
                    ret.Add(new TiempoFuncionamiento(item.MinutosNormal, item.MinutosSuspendida));
                }
            }

            return ret;
        }

        public static List<TiempoFuncionamiento> GetBetweenDates(Manager manager, DateTime desde, DateTime hasta)
        {
            var ret = new List<TiempoFuncionamiento>();
            var fechasEstado = manager.FechaestadoServicio.Where(x => x.Fecha >= desde && x.Fecha.Date <= hasta);

            if (fechasEstado != null && fechasEstado.Count() > 0)
            {
                var lineasPrecalculadas = manager.Precalculados.Where(x => fechasEstado.Any(y => y.Id == x.IdFecha)).ToList();

                lineasPrecalculadas = lineasPrecalculadas.GroupBy(x => x.IdLinea).Select(g => new Precalculado
                {
                    MinutosNormal = g.Sum(x => x.MinutosNormal),
                    MinutosSuspendida = g.Sum(x => x.MinutosSuspendida),
                    MinutosDemora = g.Sum(x => x.MinutosDemora),
                    MinutosLimitada = g.Sum(x => x.MinutosLimitada),
                }).ToList();               

                foreach (var item in lineasPrecalculadas)
                {
                    ret.Add(new TiempoFuncionamiento(item));
                }
            }

            return ret;
        }
    }
  
}
