using EventoUp.Data;
using EventoUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private EventoUpContext _context;

    public EventoController(EventoUpContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CriarEvento(
        [FromBody] Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEventoPorID), new { id = evento.id }, evento);
    }


    [HttpGet]
    public IEnumerable<Evento> RecuperaEventos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Eventos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEventoPorID(int id)
    {
        var evento = _context.Eventos.FirstOrDefault(evento => evento.id == id);
        return evento != null ? Ok(evento) : NotFound();
    }

}
