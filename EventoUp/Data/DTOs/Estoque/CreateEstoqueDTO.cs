using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Estoque;

public class CreateEstoqueDTO
{
    [Required]
    public int EventoId { get; set; }
    public DateTime CriadoEm { get; private set; } = DateTime.Now;
}
