using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Estoque
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int EventoId { get; set; }

    public virtual Evento Evento { get; set; }

    public DateTime CriadoEm { get; private set; }

    public DateTime AlteradoEm { get; private set; }
}
