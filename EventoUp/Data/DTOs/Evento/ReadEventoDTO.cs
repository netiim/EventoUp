using EventoUp.Data.DTOs.Usuario;
using EventoUp.Models;
using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Evento
{
    public class ReadEventoDTO
    {
        public string? Nome { get; set; }
        public string? Local { get; set; }
        public int Capacidade { get; set; }
        public string? Genero { get; set; }
        public DateTime DataDoEvento { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AlteradoEm { get; private set; }
        public ReadUsuarioResponsavelDTO UsuarioResponsavel { get; set; }
        public  Estoque Estoque { get; set; }
    }
}
