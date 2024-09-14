using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.Models
{
    public class Entrega
    {
        [Key]
        public int EntregaId { get; set; }

        [Required(ErrorMessage = "El ID del pedido es obligatorio.")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "El estado de la entrega es obligatorio.")]
        public string Estado { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
