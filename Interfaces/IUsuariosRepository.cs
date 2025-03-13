
using Projeto_EventPlus.Domains;

namespace projeto_event_plus.Interfaces
{
    public interface IUsuariosRepository
    {
        //cadastrar
        void Cadastrar(Usuarios usuarios);

        //buscar por id
        Usuarios BuscarPorId(Guid id);

        //buscar por email e senha 
        Usuarios BuscarPorEmailESenha(string Email, string Senha);

    }
}
