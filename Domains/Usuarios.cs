using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    public class Usuarios
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [ForeignKey("TipoUsuario")]
        public Guid IdTipoUsuario { get; set; }

        public String? NomeUsuario { get; set; }

        public String? Email { get; set; }

        public String? Senha { get; set; }
    }
}
