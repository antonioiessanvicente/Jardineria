using Microsoft.EntityFrameworkCore;
using APIJardineria.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace APIJardineria.Models
{

    // Contexto de la Base de datos
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {
        }

        // El campo debe tener el mismo nombre que la tabla de la BD
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Gama_Producto> gama_Producto { get; set; }
        public DbSet<Oficina> Oficina { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }


        // Clave primaria compuesta de linped y localidad
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalle_Pedido>()
                .HasKey(l => new { l.Codigo_Pedido, l.Numero_linea });

        }

    }
}
