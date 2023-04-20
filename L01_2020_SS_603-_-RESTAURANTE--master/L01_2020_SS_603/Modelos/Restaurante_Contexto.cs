using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Identity.Client;

namespace L01_2020_SS_603.Modelos
{
    public class Restaurante_Contexto :DbContext
    {
        public Restaurante_Contexto(DbContextOptions<Restaurante_Contexto> options) : base(options) 
        {   
        }

        public DbSet<restaurantejeje> restaurante { get; set; }

        public DbSet<platos> platos { get; set;  }

        public DbSet<pedidos> pedidos { get; set; }

        public DbSet<motorista> motorista { get; set; }
    }
}
