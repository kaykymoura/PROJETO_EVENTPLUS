using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto_EventPlus.Domains
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]


    public class Usuarios
    {
        [Key]
        public Guid IdUsuario { get; set; }

        //Referencia para a entidade TiposUsuarios
        [Required(ErrorMessage = "O tipo do usuario e obrigatorio!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTiposUsuarios")]
        public TiposUsuarios? TipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o nome e obrigatorio!")]
        public String? NomeUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email e obrigatorio!")]
        public String? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha e obrigatoria!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 60")]
        public String? Senha { get; set; }


    }

}
