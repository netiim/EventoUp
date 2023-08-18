using EventoUp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventoUp.Data
{
    public class EventoUpContext : DbContext
    {
        public EventoUpContext(DbContextOptions<EventoUpContext> opts)
            : base(opts)
        {

        }
       
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
    }
}
