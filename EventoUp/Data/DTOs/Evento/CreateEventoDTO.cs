using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Evento;
/// <summary>
/// DTO utilizada para preencher o objeto que vai criar um evento
/// </summary>
public class CreateEventoDTO
{
    /// <summary>
    /// Nome do Evento
    /// </summary>
    [Required]
    public string? Nome { get; set; }
    /// <summary>
    /// Nome do Local do evento
    /// </summary>
    [Required]
    public string? Local { get; set; }
    /// <summary>
    /// Capacidade de pessoas suportada pelo local
    /// </summary>
    [Range(1, 9999)]
    public int Capacidade { get; set; }
    /// <summary>
    /// Genêro do evento
    /// </summary>
    [Required]
    public string? Genero { get; set; }
    /// <summary>
    /// Data que irá acontecer o evento
    /// </summary>
    [Required]
    public DateTime DataDoEvento { get; set; }
    /// <summary>
    /// Breve descrição sobre o evento
    /// </summary>
    public string? Descricao { get; set; }

    [Required]
    public DateTime CriadoEm { get; private set; } = DateTime.Now;

    [Required]
    public int UsuarioId { get; set; }
}
