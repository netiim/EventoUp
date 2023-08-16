using AutoMapper;
using EventoUp.Data;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Produto;
using EventoUp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private EventoUpContext _context;
    private IMapper _mapper;

    public ProdutoController(EventoUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///  Adiciona um produto ao banco de dados
    /// </summary>
    /// <param name="produto"></param>
    /// <returns>IActionResults</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>    
    [HttpPost]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
    public IActionResult CriarProduto(
    [FromBody] Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoPorID), new { id = produto.id }, produto);
    }

    [HttpGet]
    public IEnumerable<Produto> RecuperaProdutos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Produtos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoPorID(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.id == id);
        return produto != null ? Ok(produto) : NotFound();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaProdutoParcial(int id,
      JsonPatchDocument<UpdateProdutoDTO> patch)
    {
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.id == id);

        if (produto == null) return NotFound();

        var ProdutoParaAtualizar = _mapper.Map<UpdateProdutoDTO>(produto);

        patch.ApplyTo(ProdutoParaAtualizar, ModelState);

        if (!TryValidateModel(ProdutoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(ProdutoParaAtualizar, produto);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult ApagaProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.id == id);

        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return NoContent();
    }
}
