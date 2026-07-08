namespace PedidosGraphQL.Api.Models;

public enum EstadoPedido
{
    Pendiente,
    Enviado,
    Entregado,
    Cancelado
}

public class Pedido
{
    public int Id { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public DateTime FechaPedido { get; set; }

    public EstadoPedido Estado { get; set; }

    public decimal Total { get; set; }
}
