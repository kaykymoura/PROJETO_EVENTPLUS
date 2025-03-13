using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class EventoRepository : IEventosRepository
    {
        public void Atualizar(Guid id, Eventos eventos)
        {
            throw new NotImplementedException();
        }

        public Eventos BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Eventos eventos)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Eventos> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Eventos> ListarProximosEventos()
        {
            throw new NotImplementedException();
        }
    }
}
