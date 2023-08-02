using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Produto
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    //[MinLength(0)]
    public int Quantidade { get; set; }
    [Required]
    //[MinLength(0)]
    public decimal Preco { get; set; }  
}
