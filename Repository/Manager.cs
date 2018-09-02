using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Manager
    {
        private subtedataContext _manager;

        public Manager(subtedataContext context)
        {
            _manager = context;
        }

        public DbSet<Estadoservicio> EstadoServicio
        {
            get
            {
                return _manager.Estadoservicio;
            }
        }

        public DbSet<Fechaestadoservicio> FechaestadoServicio
        {
            get
            {
                return _manager.Fechaestadoservicio;
            }
        }

        public DbSet<Precalculado> Precalculados
        {
            get
            {
                return _manager.Precalculado;
            }
        }

        public DbSet<Linea> Linea
        {
            get
            {
                return _manager.Linea;
            }
        }


        public DbSet<Itinerario> Itinerario
        {
            get
            {
                return _manager.Itinerario;
            }
        }

        public void SaveChanges()
        {
            _manager.SaveChanges();
        }
    }
}
