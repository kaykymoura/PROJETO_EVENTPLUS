using Microsoft.EntityFrameworkCore;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Contexts
{
    public class Event_Context : DbContext
    {

        public Event_Context()
        {
        }

        public Event_Context(DbContextOptions<Event_Context> options) : base(options)
        {
        }

        /// <summary>
        /// Define que as tabelas se transformarao em tabelas no BD "BANCO DE DADOS"
        /// </summary>
        

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<TiposEventos> TiposEventos { get; set; }

        public DbSet<TiposUsuarios> TiposUsuarios { get;set; }

        public DbSet<PresencasEventos> PresencasEventos { get;set; }

        public DbSet<Instituicoes> Instituicoes { get; set; }

        public DbSet<Eventos> Eventos { get; set; }

        public DbSet<ComentarioEvento> ComentarioEventos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =NOTE22-S28\\SQLEXPRESS; Database = Projeto_EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }
        }

    }
         
    
}
