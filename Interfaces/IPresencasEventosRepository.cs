
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IPresencasEventosRepository
    {
        //deletar
        void Deletar(Guid id);

        //listar
        List<PresencasEventos> Listar();

        //buscar por id 
        PresencasEventos BuscarPorId(Guid id);

        //atualizar
        void Atualizar(Guid id, PresencasEventos presencasEventos);

        //listar minhas 
        List<PresencasEventos> ListarMinhas(Guid id);

        //inscrever 
        void Inscrever(PresencasEventos inscricao);



    }
}
