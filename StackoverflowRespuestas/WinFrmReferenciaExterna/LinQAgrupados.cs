using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmReferenciaExterna
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int TipoUnidad { get; set; }
    }

    public class PedidoAGrupado
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public List<Producto> Productos { get; set; }
    }

    public class Producto
    {
        public int IdProducto { get; set; }
        public int TipoUnidad { get; set; }
    }

    public class LinQAgrupados
    {
        public void Lanzar()
        {
            List<Pedido> pedidos = new List<Pedido>
        {
            new Pedido{ IdPedido = 655, IdCliente = 10770, IdProducto = 3, TipoUnidad = 1},
            new Pedido{ IdPedido = 655, IdCliente = 10770, IdProducto = 4, TipoUnidad = 1},
            new Pedido{ IdPedido = 656, IdCliente = 10778, IdProducto = 2, TipoUnidad = 3},
            new Pedido{ IdPedido = 656, IdCliente = 10778, IdProducto = 1, TipoUnidad = 6}
        };

            var listaAgrupada = pedidos.GroupBy(p => new { p.IdPedido, p.IdCliente })
                .Select(x => new PedidoAGrupado
                {
                    IdPedido = x.Key.IdPedido,
                    IdCliente = x.Key.IdCliente,
                    Productos = x.ToList().Select(y => new Producto
                    {
                        IdProducto = y.IdProducto,
                        TipoUnidad = y.TipoUnidad
                    }).ToList()
                }).ToList();

            var agrupacion = from p in pedidos
                             group p by new { p.IdPedido, p.IdCliente };
            var listaAGrupada2 = (from x in agrupacion
                                 select new PedidoAGrupado
                                 {
                                     IdPedido = x.Key.IdPedido,
                                     IdCliente = x.Key.IdCliente,
                                     Productos = x.ToList().Select(y => new Producto
                                     {
                                         IdProducto = y.IdProducto,
                                         TipoUnidad = y.TipoUnidad
                                     }).ToList()
                                 }).ToList();
        }
    }
}
