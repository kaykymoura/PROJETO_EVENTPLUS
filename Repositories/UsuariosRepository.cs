
using Microsoft.AspNetCore.Identity;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Api_Event.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Event_Context _context;

        public UsuarioRepository(Event_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuarios
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            IdTiposUsuario = u.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado!;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuarios
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            IdTiposUsuario = u.TipoUsuario!.IdTiposUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            try
            {
                usuarios.IdUsuario = Guid.NewGuid();

                _context.Usuarios.Add(usuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}