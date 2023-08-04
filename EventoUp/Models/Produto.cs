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
    [Range(1, 99999)]
    public int Quantidade { get; set; }
    [Required]
    [Range(1, 99999)]
    public decimal Preco { get; set; }  
}
