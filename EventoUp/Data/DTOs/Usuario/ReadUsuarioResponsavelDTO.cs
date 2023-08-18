namespace EventoUp.Data.DTOs.Usuario
{
    /// <summary>
    /// DTO utilizado para retornar algumas propriedades quando o usuário realizar a busca de usuários no banco
    /// </summary>
    public class ReadUsuarioResponsavelDTO
    { /// <summary>
      /// Identificador do usuário
      /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome Completo do usuário
        /// </summary>
        public string? Nome { get; set; }
        /// <summary>
        /// Email do usuário 
        /// </summary>
        public string? Email { get; set; }
       
    }
}
