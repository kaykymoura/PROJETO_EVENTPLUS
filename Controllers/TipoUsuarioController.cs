using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITiposUsuariosRepository _tiposUsuariosRepository;

        public TipoUsuarioController(ITiposUsuariosRepository tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }

        // Cadastrar 
        [HttpPost]
        public IActionResult Post(TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Cadastrar(tiposUsuarios);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tiposUsuariosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao deletar o usuário.");
            }
        }

        // Listar todos os tipos de usuários 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuarios> tiposUsuarios = _tiposUsuariosRepository.Listar();
                return Ok(tiposUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Buscar por ID
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _tiposUsuariosRepository.BuscarPorId(id);

                if (tiposUsuariosBuscado == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                return Ok(tiposUsuariosBuscado);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar usuário: {e.Message}");
            }
        }

        // Atualizar 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Atualizar(id, tiposUsuarios);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
