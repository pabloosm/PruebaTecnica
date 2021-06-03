using API_GEO.Models;
using Microsoft.EntityFrameworkCore;


namespace API_GEO.DB
{
    public abstract class AbstractPedidosDBContext : DbContext
    {
        public DbSet<PedidoModel> PEDIDOS { get; set; }


        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pedidos.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
