using EventoUp.Data;
using EventoUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private EventoUpContext _context;

    public ProdutoController(EventoUpContext context)
    {
        _context = context;
    }

    [HttpPost]
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
}
