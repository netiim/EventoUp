using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;
/// <summary>
/// Classe usada como modelo para o banco de dados
/// </summary>
public class Evento
{
    /// <summary>
    /// Identificador da classe
    /// </summary>
    [Key]
    [Required]
    public int id { get; set; }

    /// <summary>
    /// Nome do Evento
    /// </summary>
    [Required]
    public string? Nome { get; set; }

    /// <summary>
    /// Nome do Local do evento
    /// </summary>
    [Required]    
    public string? Local  { get; set; }

    /// <summary>
    /// Capacidade de pessoas suportada pelo local
    /// </summary>
    [Range(1,9999)]
    public int Capacidade  { get; set; }

    /// <summary>
    /// Genêro do evento
    /// </summary>
    [Required]    
    public string? Genero  { get; set; }

    /// <summary>
    /// Data que irá acontecer o evento
    /// </summary>
    [Required]    
    public DateTime DataDoEvento  { get; set; }

    /// <summary>
    /// Breve descrição sobre o evento
    /// </summary>
    public string? Descricao  { get; set; }

    /// <summary>
    /// Data de criação do evento
    /// </summary>
    [Required]
    public DateTime CriadoEm { get; private set; }
    /// <summary>
    /// Data de alterações feitas no evento
    /// </summary>
    public DateTime AlteradoEm { get; private set; }

    /// <summary>
    /// Usuario ID responsavel pelo evento
    /// </summary>
    [Required]
    public int UsuarioId { get; set; }

    /// <summary>
    /// Objeto do usuario responsavel pelo evento
    /// </summary>
    public virtual Usuario? UsuarioAdministrador { get; set; }

    /// <summary>
    /// Estoque do evento
    /// </summary>
    public virtual Estoque? Estoque { get; set; }
}
