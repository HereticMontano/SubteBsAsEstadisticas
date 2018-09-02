using Repository;
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
            var fechaEstado = manager.FechaestadoServicio.First(x => x.Fecha.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString());
            var lineasPrecalculadas = manager.Precalculados.Where(x => x.IdFecha == fechaEstado.Id);

            foreach (var item in lineasPrecalculadas)
            {
                ret.Add(new TiempoFuncionamiento (item.MinutosNormal.Value, item.MinutosSuspendida));
            }

            return ret;
        }
    }
  
}
