using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using MiIngresoHitss.Models;

namespace MiIngresoHitss.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ListaPrecio> ListasPrecios { get; set; }
        public DbSet<ProductoListaPrecio> ProductoListaPrecios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la clave primaria compuesta para ProductoListaPrecio
            modelBuilder.Entity<ProductoListaPrecio>()
                .HasKey(plp => new { plp.ProductoID, plp.ListaPrecioID });

            // Configurar las relaciones
            modelBuilder.Entity<ProductoListaPrecio>()
                .HasOne(plp => plp.Producto)
                .WithMany(p => p.ProductoListaPrecios)
                .HasForeignKey(plp => plp.ProductoID);

            modelBuilder.Entity<ProductoListaPrecio>()
                .HasOne(plp => plp.ListaPrecio)
                .WithMany(lp => lp.ProductoListaPrecios)
                .HasForeignKey(plp => plp.ListaPrecioID);
        }
    }

    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad de navegación
        public ICollection<ProductoListaPrecio> ProductoListaPrecios { get; set; }
    }

    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }

    public class ListaPrecio
    {
        public int ListaPrecioID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Propiedad de navegación
        public ICollection<ProductoListaPrecio> ProductoListaPrecios { get; set; }
    }

    public class ProductoListaPrecio
    {
        public int ProductoID { get; set; }
        public int ListaPrecioID { get; set; }
        public decimal Precio { get; set; }

        // Propiedades de navegación
        public Producto Producto { get; set; }
        public ListaPrecio ListaPrecio { get; set; }
    }

    public class Venta
    {
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
