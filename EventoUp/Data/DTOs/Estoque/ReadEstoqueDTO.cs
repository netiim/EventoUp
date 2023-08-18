using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Produto;
using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Estoque;

public class ReadEstoqueDTO
{  
    public int EventoId { get; set; }

    public virtual ReadEventoResumidoDTO Evento { get; set; }

    public virtual ICollection<ReadProdutoDTO> Produtos { get; set; }
}
