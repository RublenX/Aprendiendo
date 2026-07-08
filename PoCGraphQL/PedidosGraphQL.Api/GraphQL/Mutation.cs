using Microsoft.EntityFrameworkCore;
using PedidosGraphQL.Api.Data;
using PedidosGraphQL.Api.Models;

namespace PedidosGraphQL.Api.GraphQL;

public class Mutation
{
    public async Task<Pedido> AddPedidoAsync(AddPedidoInput input, PedidosDbContext context, CancellationToken cancellationToken)
    {
        var pedido = new Pedido
        {
            Cliente = input.Cliente,
            FechaPedido = input.FechaPedido,
            Estado = input.Estado,
            Total = input.Total
        };

        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync(cancellationToken);

        return pedido;
    }

    public async Task<Pedido?> UpdatePedidoAsync(UpdatePedidoInput input, PedidosDbContext context, CancellationToken cancellationToken)
    {
        var pedido = await context.Pedidos.FindAsync(new object?[] { input.Id }, cancellationToken);
        if (pedido is null)
        {
            return null;
        }

        pedido.Cliente = input.Cliente;
        pedido.FechaPedido = input.FechaPedido;
        pedido.Estado = input.Estado;
        pedido.Total = input.Total;

        await context.SaveChangesAsync(cancellationToken);

        return pedido;
    }

    public async Task<bool> DeletePedidoAsync(int id, PedidosDbContext context, CancellationToken cancellationToken)
    {
        var pedido = await context.Pedidos.FindAsync(new object?[] { id }, cancellationToken);
        if (pedido is null)
        {
            return false;
        }

        context.Pedidos.Remove(pedido);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
