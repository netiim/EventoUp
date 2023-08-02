using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;

public class Usuario
{
    [Required(ErrorMessage = "É necessário digitar um Nome.")]
    public string? Nome { get; private set; }

    [Required(ErrorMessage = "É necessário digitar uma Senha.")]
    public string? Senha { get; private set; }

    [Required(ErrorMessage = "É necessário digitar um Email.")]
    public string? Email { get; private set; }

    [Required(ErrorMessage = "É necessário digitar um CPF.")]
    public string? Cpf { get; private set; }

    [Required(ErrorMessage = "É necessário digitar uma Data Nascimento.")]
    public DateTime DataNascimento { get; private set; }
}
