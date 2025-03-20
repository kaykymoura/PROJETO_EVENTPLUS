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
                TiposEventos tiposEventosBuscado = _context.TiposEventos.Find(id)!;

                if (tiposEventosBuscado != null)
                {
                    tiposEventosBuscado.IdTipoEvento = tiposEventos.IdTipoEvento;
                    tiposEventosBuscado.TituloTipoEvento = tiposEventos.TituloTipoEvento;

                    _context.TiposEventos.Update(tiposEventosBuscado);
                    _context.SaveChanges();
                }
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
                TiposEventos tipoEventoBuscado = _context.TiposEventos.Find(id)!;
                return tipoEventoBuscado;

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
                TiposEventos tipoEventoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    _context.TiposEventos.Remove(tipoEventoBuscado);
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
                List<TiposEventos> listaDeEventos = _context.TiposEventos.ToList();
                return listaDeEventos;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
