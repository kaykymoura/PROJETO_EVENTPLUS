using System.ComponentModel.DataAnnotations;

namespace Projeto_EventPlus.Domains
{
    public class TiposUsuarios
    {
        [Key]
        public Guid IdTiposUsuario { get; set; }

        public String? TituloTipoUsuario { get; set; }
    }
}
