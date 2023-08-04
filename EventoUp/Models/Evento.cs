using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Evento
{
    [Key]
    [Required]
    public int id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]    
    public string? Local  { get; set; }

    [Range(1,9999)]
    public int Capacidade  { get; set; }

    [Required]    
    public string? Genero  { get; set; }

    [Required]    
    public DateTime DataDoEvento  { get; set; }  
    
    public string? Descricao  { get; set; }

    [Required]
    public DateTime CriadoEm { get; private set; }

    public DateTime AlteradoEm { get; private set; }
}
