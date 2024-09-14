using System.ComponentModel.DataAnnotations;

namespace APIMercancías_JyC.DTOs
{
    public class EntregaDTO
    {
        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        public string Estado { get; set; } = "Pendiente";
    }
}
