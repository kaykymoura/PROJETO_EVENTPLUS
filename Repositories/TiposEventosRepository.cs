using Microsoft.EntityFrameworkCore;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace EventPlus_.Repositories
{
    public class TipoEventoRepository : ITiposEventosRepository
    {
        private readonly Event_Context _context;

        public TipoEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TiposEventos tiposEventos)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tiposEventos != null)
                {
                    tipoBuscado.TituloTipoEvento = tiposEventos.TituloTipoEvento;
                }

                _context.TiposEventos.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEventos.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposEventos novoTipoEvento)
        {
            try
            {
                novoTipoEvento.IdTipoEvento = Guid.NewGuid(); 

                _context.TiposEventos.Add(novoTipoEvento);
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

        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
