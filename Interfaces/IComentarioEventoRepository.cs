
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IComentarioEventoRepository
    {
        //cadastrar
        void Cadastrar(ComentarioEvento comentarioEvento);

        //deletar 
        void Deletar(Guid id);

        //listar 
        List<ComentarioEvento> Listar(Guid id);

        //BuscarPorIdUsuario
        ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid IdEvento);
    }
}
