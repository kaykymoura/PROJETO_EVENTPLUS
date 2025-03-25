using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo comentario do evento
        /// </summary>

        [HttpPost]
        public IActionResult Post(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar novo comentario do evento
        /// </summary>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar comentarios do evento
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ComentarioEvento> listaComentarioEvento = _comentarioEventoRepository.Listar();
                return Ok(listaComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por id o comentario do usuario do evento
        /// </summary>
        [HttpGet("BuscarPorIdUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentarioEvento novoComentarioEvento = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioID, EventoID);
                return Ok(novoComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}