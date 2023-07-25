using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Evento
{
    [Required]
    public string? Nome { get; private set; }
    [Required]    
    public string? Local  { get; private set; }
    public string? Capacidade  { get; private set; }
    [Required]    
    public string? Genero  { get; private set; }
    [Required]    
    public DateTime Data  { get; private set; }   
    public string? Descricao  { get; private set; }
}
