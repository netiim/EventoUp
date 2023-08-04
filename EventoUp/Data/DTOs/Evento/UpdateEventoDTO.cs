using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Evento;

public class UpdateEventoDTO
{
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Local { get; set; }

    [Range(1, 9999)]
    public int Capacidade { get; set; }

    [Required]
    public string? Genero { get; set; }

    [Required]
    public DateTime DataDoEvento { get; set; }

    public string? Descricao { get; set; }
}
