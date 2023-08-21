using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Evento;
/// <summary>
/// DTO utilizada para preencher o objeto que vai editar um evento
/// </summary>
public class UpdateEventoDTO
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

    /// <summary>
    /// Data de alterações feitas no evento
    /// </summary>
    public DateTime AlteradoEm { get; private set; }

    /// <summary>
    /// Metodo utilizado para preencher a variavel alteradoEm durante a edição
    /// </summary>
    public void PreencheValorAlteradoEm() => AlteradoEm = DateTime.Now;
}
