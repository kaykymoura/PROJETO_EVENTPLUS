using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public Usuarios BuscarPorEmailESenha(string Email, string Senha)
        {
            Usuarios usuarios = Event_Context.Usuarios.FirstOrDefault(u => u.Email == Email)!;
            if (usuarios != null) 
            {
                bool confere = Criptografia.CompararHash

        


        public Usuarios BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuarios usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
