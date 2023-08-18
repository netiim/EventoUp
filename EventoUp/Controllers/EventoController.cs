using AutoMapper;
using EventoUp.Data;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;
/// <summary>
/// Classe para controlar as ações de um Evento (CRUD) básico
/// </summary>
[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private EventoUpContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor recebe parametros para auxiliar nas consultas do banco e no mapeamento das Models com as DTOs
    /// </summary>
    /// <param name="context"> EventoUpContext usado para realizar as consultas com o banco</param>
    /// <param name="mapper"> IMapper usado para mapear as models com o DTO</param>
    public EventoController(EventoUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um evento no banco de dados
    /// </summary>
    /// <param name="eventoDTO"> A partir do parametro do tipo CreateEventoDTO será criado um registro no banco com essas informações</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(typeof(ReadEventoDTO), StatusCodes.Status201Created)]
    public IActionResult CriarEvento(
        [FromBody] CreateEventoDTO eventoDTO)
    {
        var evento = _mapper.Map<Evento>(eventoDTO);
        _context.Eventos.Add(evento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEventoPorID), new { id = evento.id }, evento);
    }

    /// <summary>
    /// Busca a lista de eventos no banco de dados
    /// </summary>
    /// <param name="skip">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pular da lista.</param>
    /// <param name="take">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pegar da lista.</param>
    /// <returns>Uma coleção de objetos do tipo <see cref="ReadEventoDTO"/>.</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadEventoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<ReadEventoDTO> RecuperaEventos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadEventoDTO>>(_context.Eventos.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Busca um evento no banco de dados
    /// </summary>
    /// <param name="id">Id do evento que será buscado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadEventoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperaEventoPorID(int id)
    {
        var evento = _context.Eventos.FirstOrDefault(evento => evento.id == id);
        var eventoDTO = _mapper.Map<ReadEventoDTO>(evento);
        return eventoDTO != null ? Ok(eventoDTO) : NotFound();
    }


    /// <summary>
    /// Edita as propriedades de um evento no banco de dados
    /// </summary>
    /// <param name="id">Id do evento que será editado no banco de dados</param>
    /// <param name="patch">Json com as propriedades do objeto UpdateEventoDTO que serão alteradas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o evento com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a alteração do evento</response>
    /// <response code="404"> Caso não encontre um evento com esse ID no banco de dados</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizaEventoParcial(int id,
        JsonPatchDocument<UpdateEventoDTO> patch)
    {
        var evento = _context.Eventos.FirstOrDefault(
            evento => evento.id == id);

        if (evento == null) return NotFound();

        var EventoParaAtualizar = _mapper.Map<UpdateEventoDTO>(evento);
        EventoParaAtualizar.PreencheValorAlteradoEm();
        patch.ApplyTo(EventoParaAtualizar, ModelState);

        if (!TryValidateModel(EventoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(EventoParaAtualizar, evento);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Apaga um evento no banco de dados
    /// </summary>
    /// <param name="id">Id do evento que será excluido no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o evento com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a exclusão do evento</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
