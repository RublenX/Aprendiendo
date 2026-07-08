using PedidosGraphQL.Api.Models;

namespace PedidosGraphQL.Api.GraphQL;

public record AddPedidoInput(string Cliente, DateTime FechaPedido, EstadoPedido Estado, decimal Total);

public record UpdatePedidoInput(int Id, string Cliente, DateTime FechaPedido, EstadoPedido Estado, decimal Total);
