using Microsoft.EntityFrameworkCore;
using PedidosGraphQL.Api.Models;

namespace PedidosGraphQL.Api.Data;

public class PedidosDbContext(DbContextOptions<PedidosDbContext> options) : DbContext(options)
{
    public DbSet<Pedido> Pedidos => Set<Pedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(p => p.Cliente).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Total).HasColumnType("numeric(18,2)");

            entity.HasData(
                new Pedido { Id = 1, Cliente = "Ana García", FechaPedido = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc), Estado = EstadoPedido.Entregado, Total = 129.90m },
                new Pedido { Id = 2, Cliente = "Luis Martínez", FechaPedido = new DateTime(2026, 2, 3, 0, 0, 0, DateTimeKind.Utc), Estado = EstadoPedido.Enviado, Total = 59.50m },
                new Pedido { Id = 3, Cliente = "Marta Sánchez", FechaPedido = new DateTime(2026, 2, 20, 0, 0, 0, DateTimeKind.Utc), Estado = EstadoPedido.Pendiente, Total = 340.00m },
                new Pedido { Id = 4, Cliente = "Carlos Ruiz", FechaPedido = new DateTime(2026, 3, 5, 0, 0, 0, DateTimeKind.Utc), Estado = EstadoPedido.Cancelado, Total = 89.99m },
                new Pedido { Id = 5, Cliente = "Elena Torres", FechaPedido = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc), Estado = EstadoPedido.Pendiente, Total = 210.25m }
            );
        });
    }
}
