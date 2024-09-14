using APIMercancías_JyC.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMercancías_JyC.Data
{
    public class MercanciasJyCContext: DbContext
    {
        public MercanciasJyCContext(DbContextOptions<MercanciasJyCContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProducto> PedidoProductos { get; set; }
        public DbSet<Entrega> Entregas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Pedido>().Property(p => p.Total).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>().Property(p => p.FechaPedido).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<Pedido>() .Property(p => p.FechaEntrega).HasColumnType("datetime").IsRequired();

            // Configuración de relaciones
            modelBuilder.Entity<PedidoProducto>().HasKey(pp => new { pp.PedidoId, pp.ProductoId });

            modelBuilder.Entity<Pedido>().HasOne(p => p.Cliente) .WithMany(c => c.Pedidos).HasForeignKey(p => p.ClienteId);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Entrega)
                .WithOne(e => e.Pedido)
                .HasForeignKey<Entrega>(e => e.PedidoId);

            modelBuilder.Entity<PedidoProducto>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<PedidoProducto>()
                .HasOne(pp => pp.Producto)
                .WithMany(p => p.PedidosProductos)
                .HasForeignKey(pp => pp.ProductoId);

            modelBuilder.Entity<Entrega>()
                .HasOne(e => e.Pedido)
                .WithOne(p => p.Entrega)
                .HasForeignKey<Entrega>(e => e.PedidoId);



        }

    }
}
