using APIMercancías_JyC.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMercancías_JyC.Models
{
    public class PedidoCreateDTO
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        // Lista de productos asociados al pedido
        [Required(ErrorMessage = "Se debe proporcionar al menos un producto para el pedido.")]
        public List<PedidoProductoDTO> PedidoProductos { get; set; }

        // Información de la entrega
        [Required(ErrorMessage = "La entrega es obligatoria.")]
        public EntregaDTO Entrega { get; set; }

    }
}
