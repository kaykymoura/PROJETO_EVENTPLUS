using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        public ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid IdEvento)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
