using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
