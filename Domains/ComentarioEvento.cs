using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("Evento")]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descricao do evento e obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A exibicao do evento e obrigatoria!")]
        public bool Exibe { get; set; }
    }
}
