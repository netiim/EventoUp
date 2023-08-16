using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Produto;

public class ReadProdutoDTO
{
    [Required]
    public string? Nome { get; set; }
    [Required]
    [Range(1, 99999)]
    public int Quantidade { get; set; }
    [Required]
    [Range(1, 99999)]
    public decimal Preco { get; set; }
}
