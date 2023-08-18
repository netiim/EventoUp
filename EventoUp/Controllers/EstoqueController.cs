using AutoMapper;
using EventoUp.Data;
using EventoUp.Data.DTOs.Estoque;
using EventoUp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueUp.Controllers;
/// <summary>
/// Classe para controlar as ações de um Estoque (CRUD) básico
/// </summary>
[ApiController]
[Route("[controller]")]
public class EstoqueController : ControllerBase
{
    private EventoUpContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor recebe parametros para auxiliar nas consultas do banco e no mapeamento das Models com as DTOs
    /// </summary>
    /// <param name="context"> EstoqueUpContext usado para realizar as consultas com o banco</param>
    /// <param name="mapper"> IMapper usado para mapear as models com o DTO</param>
    public EstoqueController(EventoUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um Estoque no banco de dados
    /// </summary>
    /// <param name="EstoqueDTO"> A partir do parametro do tipo CreateEstoqueDTO será criado um registro no banco com essas informações</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(typeof(ReadEstoqueDTO), StatusCodes.Status201Created)]
    public IActionResult CriarEstoque(
        [FromBody] CreateEstoqueDTO EstoqueDTO)
    {
        var Estoque = _mapper.Map<Estoque>(EstoqueDTO);
        _context.Estoques.Add(Estoque);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEstoquePorID), new { id = Estoque.Id }, Estoque);
    }

    /// <summary>
    /// Busca a lista de Estoques no banco de dados
    /// </summary>
    /// <param name="skip">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pular da lista.</param>
    /// <param name="take">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pegar da lista.</param>
    /// <returns>Uma coleção de objetos do tipo <see cref="ReadEstoqueDTO"/>.</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadEstoqueDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<ReadEstoqueDTO> RecuperaEstoques([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadEstoqueDTO>>(_context.Estoques.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Busca um Estoque no banco de dados
    /// </summary>
    /// <param name="id">Id do Estoque que será buscado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadEstoqueDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperaEstoquePorID(int id)
    {
        var Estoque = _context.Estoques.FirstOrDefault(Estoque => Estoque.Id == id);
        var EstoqueDTO = _mapper.Map<ReadEstoqueDTO>(Estoque);
        return EstoqueDTO != null ? Ok(EstoqueDTO) : NotFound();
    }


    /// <summary>
    /// Edita as propriedades de um Estoque no banco de dados
    /// </summary>
    /// <param name="id">Id do Estoque que será editado no banco de dados</param>
    /// <param name="patch">Json com as propriedades do objeto UpdateEstoqueDTO que serão alteradas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o Estoque com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a alteração do Estoque</response>
    /// <response code="404"> Caso não encontre um Estoque com esse ID no banco de dados</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizaEstoqueParcial(int id,
        JsonPatchDocument<UpdateEstoqueDTO> patch)
    {
        var Estoque = _context.Estoques.FirstOrDefault(
            Estoque => Estoque.Id == id);

        if (Estoque == null) return NotFound();

        var EstoqueParaAtualizar = _mapper.Map<UpdateEstoqueDTO>(Estoque);
        EstoqueParaAtualizar.PreencheValorAlteradoEm();

        patch.ApplyTo(EstoqueParaAtualizar, ModelState);

        if (!TryValidateModel(EstoqueParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(EstoqueParaAtualizar, Estoque);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Apaga um Estoque no banco de dados
    /// </summary>
    /// <param name="id">Id do Estoque que será excluido no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o Estoque com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a exclusão do Estoque</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ApagaEstoque(int id)
    {
        var Estoque = _context.Estoques.FirstOrDefault(
            Estoque => Estoque.Id == id);

        if (Estoque == null) return NotFound();

        _context.Estoques.Remove(Estoque);
        _context.SaveChanges();

        return NoContent();
    }
}
