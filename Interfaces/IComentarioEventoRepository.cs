
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid id);

        List<ComentarioEvento> Listar();

        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID);
    }
}
