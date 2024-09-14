namespace APIMercancías_JyC.DTOs
{
    public class PedidoUpdateDTO
    {
        
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total { get; set; }

        public List<PedidoProductoDTO> PedidoProductos { get; set; }
        public EntregaDTO Entrega { get; set; }
    }
}
