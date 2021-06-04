using API_GEO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.DB
{
    public class PedidosDBContext : DbContext
    {
        public DbSet<PedidoModel> PEDIDOS { get; set; }
        public DbSet<CoordenadasDireccionesModel> COORDENADAS_PEDIDOS { get; set; }
        public PedidosDBContext(DbContextOptions<PedidosDBContext> options):base(options)
        {
            Database.EnsureCreated();
        }

    }
}
