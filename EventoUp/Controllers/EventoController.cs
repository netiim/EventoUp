using AutoMapper;
using EventoUp.Data;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private EventoUpContext _context;
    private IMapper _mapper;
    public EventoController(EventoUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    [HttpPatch("{id}")]
    public IActionResult AtualizaEventoParcial(int id,
        JsonPatchDocument<UpdateEventoDTO> patch)
    {
        var evento = _context.Eventos.FirstOrDefault(
            evento => evento.id == id);

        if (evento == null) return NotFound();

        var EventoParaAtualizar = _mapper.Map<UpdateEventoDTO>(evento);

        patch.ApplyTo(EventoParaAtualizar, ModelState);

        if (!TryValidateModel(EventoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(EventoParaAtualizar, evento);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult ApagaEvento(int id)
    {
        var evento = _context.Eventos.FirstOrDefault(
            evento => evento.id == id);

        if (evento == null) return NotFound();

        _context.Eventos.Remove(evento);
        _context.SaveChanges();

        return NoContent();
    }
}
