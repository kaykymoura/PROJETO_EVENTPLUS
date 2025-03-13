using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    [Table("PresencasEventos")]
    public class PresencasEventos
    {
        [Key]
        public Guid IdPresenca { get; set; }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("Evento")]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situacao e obrigatoria!")]
        public bool Situacao { get; set; }
    }
}
