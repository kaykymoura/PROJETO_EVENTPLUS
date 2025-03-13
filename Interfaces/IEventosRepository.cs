
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IEventosRepository
    {
        //cadastrar
        void Cadastrar(Eventos eventos);

        //deletar
        void Deletar(Guid id);

        //listar
        List<Eventos> Listar();


        //listar por id 
        List<Eventos> ListarPorId(Guid id);

        //listar proximos eventos
        List<Eventos> ListarProximosEventos();

        //buscar por id
        Eventos BuscarPorId(Guid id);

        //atualizar
        void Atualizar(Guid id, Eventos eventos);



    }
}
