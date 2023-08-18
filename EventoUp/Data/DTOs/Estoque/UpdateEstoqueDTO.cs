using System.ComponentModel.DataAnnotations;

namespace EventoUp.Data.DTOs.Estoque;

public class UpdateEstoqueDTO
{
    [Required]
    public int EventoId { get; set; }
    /// <summary>
    /// Data de alterações feitas no evento
    /// </summary>
    public DateTime AlteradoEm { get; private set; }
    /// <summary>
    /// Metodo utilizado para preencher a variavel alteradoEm durante a edição
    /// </summary>
    public void PreencheValorAlteradoEm() => AlteradoEm = DateTime.Now;
}
