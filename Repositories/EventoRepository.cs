using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class EventoRepository : IEventosRepository
    {
        private readonly Event_Context _context;

        public EventoRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Eventos eventos)
        {
            try
            {
                var eventoBuscado = _context.Eventos.Find(id);

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = eventos.NomeEvento;
                    eventoBuscado.IdTipoEvento = eventos.IdTipoEvento;
                    eventoBuscado.Descricao = eventos.Descricao;
                    eventoBuscado.DataEvento = eventos.DataEvento;

                    // Explicitamente marca a entidade como alterada
                    _context.Eventos.Update(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                
                var eventoBuscado = _context.Eventos
                    .FirstOrDefault(e => e.IdEvento == id);

                return eventoBuscado!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Eventos eventos)
        {
            try
            {
                
                if (eventos.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                
                eventos.IdEvento = Guid.NewGuid();

                _context.Eventos.Add(eventos);
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
                var eventoBuscado = _context.Eventos.Find(id);

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                // Projeção para incluir dados relacionados, se necessário
                var listaEventos = _context.Eventos
                    .Select(e => new Eventos
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento
                    }).ToList();

                return listaEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                // Listando eventos específicos por ID, considerando a presença de outros dados relacionados
                var eventosPorId = _context.Eventos
                    .Where(e => e.IdEvento == id)
                    .ToList();

                return eventosPorId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarProximosEventos()
        {
            try
            {
                // Filtrando eventos com data futura
                var proximosEventos = _context.Eventos
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();

                return proximosEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
