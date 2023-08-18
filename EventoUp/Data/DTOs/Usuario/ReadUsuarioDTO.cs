using EventoUp.Data.DTOs.Evento;
using System.ComponentModel.DataAnnotations;
using EventoUp.Models;

namespace EventoUp.Data.DTOs.Usuario
{
    /// <summary>
    /// DTO utilizado para retornar algumas propriedades quando o usuário realizar a busca de usuários no banco
    /// </summary>
    public class ReadUsuarioDTO
    {
        /// <summary>
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
        /// <summary>
        /// CPF do usuário
        /// </summary>
        public string? Cpf { get; set; }
        /// <summary>
        /// Data Nascimento do usuário
        /// </summary>
        public DateTime DataNasc { get; set; }
        /// <summary>
        /// Lista de eventos que o usuario é responsavel
        /// </summary>
        public List<ReadEventoAdministradoDTO>? EventosAdministrados { get; set; }
    }
}
