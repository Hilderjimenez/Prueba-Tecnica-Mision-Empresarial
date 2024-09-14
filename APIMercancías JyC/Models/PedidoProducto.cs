using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.Models
{
    public class PedidoProducto
    {
        [Key, Column(Order = 0)]
        public int PedidoId { get; set; }

        [Key, Column(Order = 1)]
        public int ProductoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
