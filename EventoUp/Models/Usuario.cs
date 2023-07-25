using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Usuario
{
    [Required]
    public string? Nome { get; private set; }
    [Required]
    public string? Senha { get; private set; }
    [Required]
    public string? Email { get; private set; }
    [Required]
    public string? Cpf { get; private set; }
    [Required]
    public DateTime DataNascimento { get; private set; }
}
