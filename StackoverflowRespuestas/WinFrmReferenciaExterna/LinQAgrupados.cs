using System;
using System.Collections.Generic;
using System.Globalization;
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

        public class TipoCamisetaValor
        {
            public string Tipo { get; set; }
            public decimal Valor { get; set; }
        }

        /*
         * Para invocarlo:
           string csv = "1,Locard,rlocard0@php.net,Female,S,$90.80\r\n" +
                            "2,Iacobassi,siacobassi1 @timesonline.co.uk,Male,XL,$12.73\r\n" +
                            "3,Schall,dschall2 @dagondesign.com,Male,XL,$17.84\r\n" +
                            "4,Grinyov,ggrinyov3 @sphinn.com,Female,XL,$13.57\r\n" +
                            "5,Bewley,bbewley4 @cbsnews.com,Male,S,$10.20";
            new LinQAgrupados().GananciaValor(csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
         */
        public TipoCamisetaValor GananciaValor(ICollection<string> lineas)
        {
            TipoCamisetaValor resultado = null;

            List<TipoCamisetaValor> listaCamisetas = new List<TipoCamisetaValor>();

            // Recoges los resultados en el listado
            foreach (var linea in lineas)
            {
                var camposSeparados = linea.Split(',');
                listaCamisetas.Add(new TipoCamisetaValor
                {
                    Tipo = camposSeparados[4],
                    Valor = decimal.Parse(camposSeparados[5].Replace("$", string.Empty), CultureInfo.CreateSpecificCulture("en-US"))
                });
            }

            // Analizas el resultado con LinQ
            var consulta = listaCamisetas.GroupBy(l => l.Tipo).Select(x => new TipoCamisetaValor { Tipo = x.Key, Valor = x.Sum(y => y.Valor) }).OrderBy(l => l.Valor).Last();

            return resultado;
        }
    }
}
