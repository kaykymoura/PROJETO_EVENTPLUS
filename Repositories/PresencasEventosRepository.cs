using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class PresencasEventosRepository : IPresencasEventosRepository
    {
        private readonly Event_Context _context;

        public PresencasEventosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, PresencasEventos presencasEventos)
        {
            try
            {
                PresencasEventos presencas = _context.PresencasEventos.Find(id)!;

                if (presencas != null)
                {
                    presencas.IdPresenca = presencasEventos.IdPresenca;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencasEventos BuscarPorId(Guid id)
        {
            try
            {
                PresencasEventos presencaBuscada = _context.PresencasEventos.Find(id)!;
                if (presencaBuscada == null)
                {
                    throw new Exception("Presença não encontrada");
                }
                return presencaBuscada;
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
                PresencasEventos presencasEventos = _context.PresencasEventos.Find(id)!;
                if (presencasEventos == null)
                {
                    throw new Exception("Presença não encontrada para deletar");
                }
                _context.PresencasEventos.Remove(presencasEventos);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencasEventos inscricao)
        {
            try
            {
                if (inscricao == null)
                {
                    throw new ArgumentNullException(nameof(inscricao));
                }
                _context.PresencasEventos.Add(inscricao);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEventos> Listar()
        {
            try
            {
                List<PresencasEventos> listaPresencasEventos = _context.PresencasEventos.ToList();
                return listaPresencasEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEventos> ListarMinhas(Guid id)
        {
            try
            {
                List<PresencasEventos> listaMinhas = _context.PresencasEventos
                    .Where(p => p.IdPresenca == id)
                    .ToList();
                return listaMinhas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
