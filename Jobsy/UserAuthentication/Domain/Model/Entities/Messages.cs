using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jobsy.UserAuthentication.Domain.Model.Aggregates;

namespace Jobsy.UserAuthentication.Domain.Model.Entities;

    public class Messages
    {
        
        [Key]
        public int Id_Message { get; set; }
        [Required]
        [ForeignKey("Emisor")]
        public int EmisorId { get; set; }
        public User Emisor { get; set; }

        [Required]
        [ForeignKey("Receptor")]
        public int ReceptorId { get; set; }
        public User Receptor { get; set; }

        [Required]
        [StringLength(1000)]
        public string Contenido { get; set; }

        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;

        public bool Leido { get; set; } = false;

        public void MarcarComoLeido()
        {
            Leido = true;
        }
}
