using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;

namespace Projeto_EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencasEventosRepository _presencaRepository;

        public PresencaController(IPresencasEventosRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }
        /// <summary>
        /// Endpoint para deletar a presença
        /// </summary>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por Id a presença
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencasEventos novaPresenca = _presencaRepository.BuscarPorId(id);
                return Ok(novaPresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencasEventos presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das presenças
        /// </summary>
        [HttpGet("ListarPresencas")]
        public IActionResult Get()
        {
            try
            {
                List<PresencasEventos> listaPresencas = _presencaRepository.Listar();
                return Ok(listaPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencasEventos> listaMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id)!;
                return Ok(listaMinhasPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

    
