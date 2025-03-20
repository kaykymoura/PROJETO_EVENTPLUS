using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuariosRepository _usuariosRepository;

        public UsuarioController(IUsuariosRepository usuarioRepository)
        {
            _usuariosRepository = usuarioRepository;
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                _usuariosRepository.Cadastrar(usuario);
                return StatusCode(201, usuario);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuarios usuario = _usuariosRepository.BuscarPorId(id);

                if (usuario != null)
                {

                    return Ok(usuario);
                }
                return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorEmailESenha")]

        public IActionResult GetByEmailAndSenha(string email, string senha)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepository.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null!;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
