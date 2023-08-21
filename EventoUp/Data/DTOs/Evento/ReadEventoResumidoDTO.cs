namespace EventoUp.Data.DTOs.Evento
{
    /// <summary>
    /// DTO utilizada para preencher o objeto que vai ler um evento de forma resumida
    /// </summary>
    public class ReadEventoResumidoDTO
    {
        /// <summary>
        /// Nome do Evento
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Nome do Local do evento
        /// </summary>
        public string? Local { get; set; }

        /// <summary>
        /// Capacidade de pessoas suportada pelo local
        /// </summary>
        public int Capacidade { get; set; }

        /// <summary>
        /// Genêro do evento
        /// </summary>
        public string? Genero { get; set; }

        /// <summary>
        /// Data que irá acontecer o evento
        /// </summary>
        public DateTime DataDoEvento { get; set; }
    }
}
