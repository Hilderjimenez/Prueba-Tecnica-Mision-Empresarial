using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
        public string Descripcion { get; set; }

        public virtual ICollection<PedidoProducto> PedidosProductos { get; set; }
    }
}
