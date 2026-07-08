import { gql } from '@apollo/client'
import { useQuery } from '@apollo/client/react'

const GET_PEDIDOS = gql`
  query GetPedidos($first: Int!, $after: String) {
    pedidos(first: $first, after: $after) {
      nodes {
        id
        cliente
        fechaPedido
        estado
        total
      }
      pageInfo {
        hasNextPage
        endCursor
      }
    }
  }
`

interface Pedido {
  id: number
  cliente: string
  fechaPedido: string
  estado: string
  total: number
}

interface PageInfo {
  hasNextPage: boolean
  endCursor: string | null
}

interface PedidosQueryResult {
  pedidos: {
    nodes: Pedido[]
    pageInfo: PageInfo
  }
}

interface PedidosQueryVariables {
  first: number
  after: string | null
}

const PAGE_SIZE = 10

const formatoFecha = new Intl.DateTimeFormat('es-ES', { dateStyle: 'medium' })
const formatoMoneda = new Intl.NumberFormat('es-ES', { style: 'currency', currency: 'EUR' })

export function PedidosTable() {
  const { data, loading, error, fetchMore } = useQuery<PedidosQueryResult, PedidosQueryVariables>(
    GET_PEDIDOS,
    { variables: { first: PAGE_SIZE, after: null } },
  )

  if (loading && !data) {
    return <p>Cargando pedidos...</p>
  }

  if (error) {
    return <p role="alert">Error al cargar los pedidos: {error.message}</p>
  }

  const pedidos = data?.pedidos.nodes ?? []
  const pageInfo = data?.pedidos.pageInfo

  const cargarMas = () => {
    if (!pageInfo?.hasNextPage) {
      return
    }

    fetchMore({
      variables: { first: PAGE_SIZE, after: pageInfo.endCursor },
      updateQuery: (previousResult, { fetchMoreResult }) => {
        if (!fetchMoreResult) {
          return previousResult
        }

        return {
          pedidos: {
            ...fetchMoreResult.pedidos,
            nodes: [...previousResult.pedidos.nodes, ...fetchMoreResult.pedidos.nodes],
          },
        }
      },
    })
  }

  return (
    <>
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Cliente</th>
            <th>Fecha</th>
            <th>Estado</th>
            <th>Total</th>
          </tr>
        </thead>
        <tbody>
          {pedidos.map((pedido) => (
            <tr key={pedido.id}>
              <td>{pedido.id}</td>
              <td>{pedido.cliente}</td>
              <td>{formatoFecha.format(new Date(pedido.fechaPedido))}</td>
              <td>{pedido.estado}</td>
              <td>{formatoMoneda.format(pedido.total)}</td>
            </tr>
          ))}
        </tbody>
      </table>

      {pageInfo?.hasNextPage && (
        <button type="button" onClick={cargarMas}>
          Cargar más
        </button>
      )}
    </>
  )
}
