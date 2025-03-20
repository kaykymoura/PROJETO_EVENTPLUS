using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly Event_Context _context;

        public UsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                
                Usuarios usuarioBuscado = _context.UsuariosFirstOrDefault(u => u.Email == Email);

                if (usuarioBuscado != null)
                {
                    
                    bool confere = Senha == usuarioBuscado.Senha;

                    if (confere)
                    {
                        return usuarioBuscado;

                    }
                }

                return null!;
            
            catch (Exception)
            {
                
                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuarios usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
}