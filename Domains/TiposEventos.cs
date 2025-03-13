using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    [Table("TiposEventos")]
    public class TiposEventos
    {
        [Key]
        public Guid IdTipoEvento { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="O titulo do tipo do evento e obrigatorio!")]
        public String? TituloTipoEvento { get; set; }

    }
}
