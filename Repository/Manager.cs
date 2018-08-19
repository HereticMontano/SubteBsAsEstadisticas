using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Manager
    {
        private SubtedataContext _manager;

        public Manager(SubtedataContext context)
        {
            _manager = context;
        }

        public DbSet<Estadoservicio> Estadoservicio
        {
            get {
                return _manager.Estadoservicio;
            }
        }

        public DbSet<Linea> Linea
        {
            get
            {
                return _manager.Linea;
            }
        }
    }
}
