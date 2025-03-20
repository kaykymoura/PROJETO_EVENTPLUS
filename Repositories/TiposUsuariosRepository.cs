using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {

        private readonly Event_Context _context;

        public TiposUsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TiposUsuarios tiposUsuarios)
        {
            {
                try
                {
                    TiposUsuarios tiposUsuariosBuscados = _context.TiposUsuarios.Find(id)!;

                    if (tiposUsuariosBuscados != null)
                    {

                        tiposUsuariosBuscados.IdTiposUsuario = id;

                    }
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public TiposUsuarios BuscarPorId(Guid id)
        {
            try
            {

                TiposUsuarios tiposUsuariosBuscados = _context.TiposUsuarios.Find(id)!;
                return tiposUsuariosBuscados;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposUsuarios tiposUsuarios)
        {
            try
            {
                _context.TiposUsuarios.Add(tiposUsuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _context.TiposUsuarios.Find(id)!;

                if (tiposUsuariosBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tiposUsuariosBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposUsuarios> Listar()
        {
            try
            {
                List<TiposUsuarios> listaTiposUsuarios = _context.TiposUsuarios.ToList()!;

                return listaTiposUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
