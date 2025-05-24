using System.ComponentModel.DataAnnotations;

namespace plataformacomentarios.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        [Required]
        public string Sentimiento { get; set; } // "like" o "dislike"

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
