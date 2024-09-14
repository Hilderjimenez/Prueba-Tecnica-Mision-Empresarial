using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.DTOs
{
    public class PedidoProductoDTO
    {
        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

    }
}
