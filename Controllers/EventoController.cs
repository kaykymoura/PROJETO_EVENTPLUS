using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Domains;
using Projeto_EventPlus.Repositories;

namespace Projeto_EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventosRepository _eventoRepository;

        public EventoController(IEventosRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>

        [HttpPost]

        public IActionResult Post(Eventos eventoRepository)
        {
            try
            {
                _eventoRepository.Cadastrar(eventoRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.Listar();
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarProximosEventos/{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.ListarProximosEventos(id);
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorId/ {id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Eventos novoEvento = _eventoRepository.BuscarPorId(id);
                return Ok(novoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPost("{id}")]

        public IActionResult Put(Guid id, Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
    }

