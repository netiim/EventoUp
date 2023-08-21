using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Produto;

public class CreateProdutoDTO
{
    [Required]
    public string? Nome { get; set; }

    [Required]
    [Range(1, 99999)]
    public int QuantidadeDisponivel { get; set; }

    [Required]
    [Range(1, 99999)]
    public decimal PrecoPago { get; set; }

    [Required]
    public int EstoqueId { get; set; }

    public DateTime CriadoEm { get; private set; } = DateTime.Now;
}
