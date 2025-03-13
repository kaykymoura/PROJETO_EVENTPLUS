using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }

        [ForeignKey("TipoEvento")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey("Instituicao")]
        public Guid IdInstituicao { get; set; }

        public DateTime DataEvento { get; set; }

        public String? NomeEvento { get; set; }

        public String? Descricao { get; set; }
    }
}
