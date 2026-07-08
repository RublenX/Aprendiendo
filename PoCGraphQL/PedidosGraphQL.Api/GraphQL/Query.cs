using HotChocolate;
using PedidosGraphQL.Api.Data;
using PedidosGraphQL.Api.Models;

namespace PedidosGraphQL.Api.GraphQL;

public class Query
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Pedido> GetPedidos(PedidosDbContext context) => context.Pedidos;
}
