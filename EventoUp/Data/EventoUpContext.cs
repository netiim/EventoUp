using EventoUp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventoUp.Data
{
    /// <summary>
    /// Classe que vai servir como uma sessão com o banco de dados e pode ser usada para consultar e salvar instâncias de suas entidades. 
    /// </summary>
    public class EventoUpContext : DbContext
    {
        /// <summary>
        /// Construtor que permite que você crie uma instância da classe EventoUpContext fornecendo as opções necessárias para configurar como esse contexto irá se comunicar com o banco de dados.
        /// </summary>
        /// <param name="opts"></param>
        public EventoUpContext(DbContextOptions<EventoUpContext> opts)
            : base(opts)
        {

        }
        /// <summary>
        /// contexto relacionado a tabela de Produtos
        /// </summary>
        public DbSet<Produto> Produtos { get; set; }
        /// <summary>
        /// contexto relacionado a tabela de Eventos
        /// </summary>
        public DbSet<Evento> Eventos { get; set; }
        /// <summary>
        /// contexto relacionado a tabela de Usuarios
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
        /// <summary>
        /// contexto relacionado a tabela de Estoques
        /// </summary>
        public DbSet<Estoque> Estoques { get; set; }
    }
}
