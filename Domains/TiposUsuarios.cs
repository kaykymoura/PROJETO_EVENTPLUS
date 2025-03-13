using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        [Key]
        public Guid IdTiposUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o tipo do usuario e obrigatorio!")]
        public String? TituloTipoUsuario { get; set; }

    }
}
