using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_EventPlus.Domains
{
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("Evento")]
        public Guid IdEvento { get; set; }

        public Guid Descricao { get; set; }

        public bool Exibe { get; set; }
    }
}
