using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Usuario;

/// <summary>
/// DTO utilizada para preencher o objeto que vai criar um usuário
/// </summary>
public class CreateUsuarioDTO
{
    /// <summary>
    /// Nome Completo do usuário
    /// </summary>
    [Required(ErrorMessage = "É necessário digitar um Nome.")]
    public string? Nome { get; set; }
    /// <summary>
    /// Senha utilizada para autenticar no sistema
    /// </summary>
    [Required(ErrorMessage = "É necessário digitar uma Senha.")]
    public string? Senha { get; set; }
    /// <summary>
    /// Email utilizado para manter um contato do usuário com o sistema
    /// </summary>
    [Required(ErrorMessage = "É necessário digitar um Email.")]
    public string? Email { get; set; }
    /// <summary>
    /// Utilizado para realizar a autenticação do usuario no sistema
    /// </summary>
    [Required(ErrorMessage = "É necessário digitar um CPF.")]
    public string? Cpf { get; set; }
    /// <summary>
    /// Data Nascimento do usuário para verificar quais eventos o usuário possui permissão
    /// </summary>
    [Required(ErrorMessage = "É necessário digitar uma Data Nascimento.")]
    public DateTime DataNasc { get; set; }
}
