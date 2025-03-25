
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IEventosRepository
    {
            List<Eventos> Listar();

            void Cadastrar(Eventos evento);

            void Atualizar(Guid id, Eventos evento);

            void Deletar(Guid id);

            List<Eventos> ListarPorId(Guid id);

            Eventos BuscarPorId(Guid id);

            List<Eventos> ListarProximosEventos(Guid id);

    }
}
