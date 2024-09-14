using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMercancías_JyC.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public  Cliente Cliente { get; set; }
        public List<PedidoProducto> PedidoProductos { get; set; }
        public  Entrega Entrega { get; set; }
    }
}
