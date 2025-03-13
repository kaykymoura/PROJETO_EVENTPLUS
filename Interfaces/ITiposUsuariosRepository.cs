
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        //cadastrar
        void Cadastrar(TiposUsuarios tiposUsuarios);

        //deletar
        void Deletar(Guid id);

        //listar
        List<TiposUsuarios> Listar();

        //buscar por id 
        TiposUsuarios BuscarPorId(Guid id);

        //atualizar
        void Atualizar(Guid id, TiposUsuarios tiposUsuarios);

    }
}
