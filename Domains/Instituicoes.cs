using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_EventPlus.Domains
{
    [Table("Instituicoes")]
    [Index(nameof(Cnpj), IsUnique = true)]
    public class Instituicoes
    {
        [Key]
        public Guid IdInstituicoes { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O Cnpj e obrigatorio!")]
        [StringLength(14)]
        public String? Cnpj { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereco e obrigatorio!")]
        public String? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome Fantasia e obrigatorio!")]
        public String? NomeFantasia { get; set; }
    }
}
