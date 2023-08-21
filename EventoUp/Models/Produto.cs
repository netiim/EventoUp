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
    public int QuantidadeDisponivel { get; set; }    
    [Required]
    [Range(1, 99999)]
    public int QuantidadeVendida { get; set; }
    [Required]
    [Range(1, 99999)]
    public int QuantidadeEstragada { get; set; }
    [Required]
    [Range(1, 99999)]
    public decimal PrecoPago { get; set; }
    [Required]
    [Range(1, 99999)]
    public decimal PrecoRevenda { get; set; }

    /// <summary>
    /// Data de criação do evento
    /// </summary>
    [Required]
    public DateTime CriadoEm { get; private set; }
    /// <summary>
    /// Data de alterações feitas no evento
    /// </summary>
    public DateTime AlteradoEm { get; private set; }

    [Required]
    public int EstoqueId { get; set; }

    public virtual Estoque Estoque { get; set; }


}
