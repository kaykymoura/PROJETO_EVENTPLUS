
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
            {
                try
                {
                    TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                    if (tipoBuscado != null)
                    {
                        tipoBuscado.TituloTipoUsuario = tiposUsuarios.TituloTipoUsuario;
                    }

                    _context.TiposUsuarios.Update(tipoBuscado!);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public TiposUsuarios BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposUsuarios.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposUsuarios tiposUsuarios)
        {
            try
            {
                tiposUsuarios.IdTiposUsuario = Guid.NewGuid();

                _context.TiposUsuarios.Add(tiposUsuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TiposUsuarios> Listar()
        {
            try
            {
                return _context.TiposUsuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
