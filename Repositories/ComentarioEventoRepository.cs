using Microsoft.AspNetCore.Mvc;
using projeto_event_plus.Interfaces;
using Projeto_EventPlus.Contexts;
using Projeto_EventPlus.Domains;

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


public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly Event_Context _context;

    public ComentarioEventoRepository(Event_Context context)
    {
        _context = context;
    }

    public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID)
    {
        try
        {
            return _context.ComentarioEvento
               .Select(c => new ComentarioEvento
               {
                   IdComentarioEvento = c.ComentarioEventoID,
                   Descricao = c.Descricao,
                   Exibe = c.Exibe,
                   UsuarioID = c.UsuarioID,
                   EventosID = c.EventosID,

                   Usuario = new Usuario
                   {
                       Nome = c.Usuario!.Nome
                   },

                   Eventos = new Eventos
                   {
                       NomeEvento = c.Eventos!.NomeEvento,
                   }

               }).FirstOrDefault(c => c.UsuarioID == UsuarioID && c.UsuarioID == EventosID)!;


        }
        catch (Exception)
        {
            throw;
        }

    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        try
        {
            comentarioEvento.IdComentarioEvento = Guid.NewGuid();

            _context.ComentarioEvento.Add(comentarioEvento);

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
            ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id)!;

            if (comentarioEventoBuscado != null)
            {
                _context.ComentarioEvento.Remove(comentarioEventoBuscado);
            }
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<ComentarioEvento> Listar()
    {
        try
        {
            return _context.ComentarioEvento
                .Select(c => new ComentarioEvento
                {
                    IdComentarioEvento = c.ComentarioEventoID,
                    Descricao = c.Descricao,
                    Exibe = c.Exibe,
                    IdUsuario = c.UsuarioID,
                    IdEvento = c.EventosID,

                    IdUsuario = new Usuarios
                    {
                        Nome = c.Usuario!.Nome
                    },

                    IdEvento = new Eventos
                    {
                        NomeEvento = c.Eventos!.NomeEvento,
                    }

                }).Where(c => c.EventosID == id).ToList();
        }
        catch (Exception)
        {

            throw;
        }
    }
}