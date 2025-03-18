using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private readonly Event_Context _context;

        public TiposUsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TiposUsuarios tiposUsuarios)
        {
            throw new NotImplementedException();
        }

        public TiposUsuarios BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuarios novoTiposUsuarios)
        {
            try
            {
                _context.TiposUsuarios.Add(novoTiposUsuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuarios> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
        