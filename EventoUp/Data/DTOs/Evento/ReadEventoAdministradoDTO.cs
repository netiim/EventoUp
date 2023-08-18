namespace EventoUp.Data.DTOs.Evento
{
    public class ReadEventoAdministradoDTO
    {
        public string? Nome { get; set; }
        public string? Local { get; set; }
        public int Capacidade { get; set; }
        public string? Genero { get; set; }
        public DateTime DataDoEvento { get; set; }
    }
}
