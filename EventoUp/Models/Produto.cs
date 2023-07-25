using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Produto
{
    [Required]
    public string? Nome { get; private set; }
    [Required]
    [MinLength(0)]
    public int Quantidade { get; private set; }
    [Required]
    [MinLength(0)]
    public decimal Preco { get; private set; }  
}
