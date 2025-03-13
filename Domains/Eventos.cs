using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }

        [ForeignKey("TipoEvento")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey("Instituicao")]
        public Guid IdInstituicao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento e obrigatoria!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento e obrigatorio")]
        public String? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao do evento e obrigatoria!")]
        public String? Descricao { get; set; }
    }
}
