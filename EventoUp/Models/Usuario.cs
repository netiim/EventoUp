using System.ComponentModel.DataAnnotations;

namespace EventoUp.Models;
/// <summary>
/// Classe usada como modelo para o banco de dados
/// </summary>
public class Usuario
{
    /// <summary>
    /// Identificador da classe
    /// </summary>
    [Key]
    [Required]    
    public int Id { get; set; }
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
    /// <summary>
    /// Data de criação do evento
    /// </summary>
    public DateTime CriadoEm { get; private set; }
    /// <summary>
    /// Data de alterações feitas no evento
    /// </summary>
    public DateTime AlteradoEm { get; private set; }
    /// <summary>
    /// Lista de eventos que o usuario é responsavel
    /// </summary>
    public virtual ICollection<Evento>? EventosAdministrados { get; set; }
}
