using AutoMapper;
using EventoUp.Data;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Usuario;
using EventoUp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventoUp.Controllers;
/// <summary>
/// Classe para controlar as ações de um Usuário (CRUD) básico
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private EventoUpContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor recebe parametros para auxiliar nas consultas do banco e no mapeamento das Models com as DTOs
    /// </summary>
    /// <param name="context"> EventoUpContext usado para realizar as consultas com o banco</param>
    /// <param name="mapper"> IMapper usado para mapear as models com o DTO</param>
    public UsuarioController(EventoUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///  Adiciona um Usuario ao banco de dados
    /// </summary>
    /// <param name="UsuarioDTO">Usuario contendo as informações que serão cadastradas no banco de dados</param>
    /// <returns>IActionResults</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>    
    [HttpPost]
    [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
    public IActionResult CriarUsuario(
    [FromBody] CreateUsuarioDTO UsuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(UsuarioDTO);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        var readUsuario = _mapper.Map<ReadUsuarioDTO>(usuario);
        return CreatedAtAction(nameof(RecuperaUsuarioPorID), new { id = usuario.Id }, readUsuario);
    }

    /// <summary>
    /// Busca a lista de usuários no banco de dados
    /// </summary>
    /// <param name="skip">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pular da lista.</param>
    /// <param name="take">parametro usado para ajudar na paginação, nesse caso para saber quantos itens pegar da lista.</param>
    /// <returns>Uma coleção de objetos do tipo <see cref="ReadUsuarioDTO"/>.</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadUsuarioDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IEnumerable<ReadUsuarioDTO> RecuperaUsuarios([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadUsuarioDTO>>(_context.Usuarios.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Busca um usuário no banco de dados
    /// </summary>
    /// <param name="id">Id do usuário que será buscado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a lista seja recuperada com sucesso</response>
    /// <response code="400">Caso a lista não consiga ser recuperada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadUsuarioDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperaUsuarioPorID(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(Usuario => Usuario.Id == id);
        var readUsuario = _mapper.Map<ReadUsuarioDTO>(usuario);
        return readUsuario != null ? Ok(readUsuario) : NotFound();
    }

    /// <summary>
    /// Edita as propriedades de um usuário no banco de dados
    /// </summary>
    /// <param name="id">Id do usuário que será editado no banco de dados</param>
    /// <param name="patch">Json com as propriedades do objeto UpdateUsuarioDTO que serão alteradas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o usuário com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a alteração do usuário</response>
    /// <response code="404"> Caso não encontre um usuário com esse ID no banco de dados</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizaUsuarioParcial(int id,
      JsonPatchDocument<UpdateUsuarioDTO> patch)
    {
        var Usuario = _context.Usuarios.FirstOrDefault(
            Usuario => Usuario.Id == id);
        if (Usuario == null) return NotFound();

        UpdateUsuarioDTO UsuarioParaAtualizar = _mapper.Map<UpdateUsuarioDTO>(Usuario);
        UsuarioParaAtualizar.PreencheValorAlteradoEm();

        patch.ApplyTo(UsuarioParaAtualizar, ModelState);

        if (!TryValidateModel(UsuarioParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(UsuarioParaAtualizar, Usuario);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Apaga um usuário no banco de dados
    /// </summary>
    /// <param name="id">Id do usuário que será excluido no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso consiga alterar o usuário com sucesso</response>
    /// <response code="400"> Caso aconteça algum problema durante a exclusão do usuário</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ApagaUsuario(int id)
    {
        var Usuario = _context.Usuarios.FirstOrDefault(
            Usuario => Usuario.Id == id);

        if (Usuario == null) return NotFound();

        _context.Usuarios.Remove(Usuario);
        _context.SaveChanges();

        return NoContent();
    }
}
