using Dominio.InterfaceModel;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IModelRepositorio<Usuario> _repositorioUsuario;

        public UsuarioController(IModelRepositorio<Usuario> repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        [HttpGet("obter-usuarios")]
        public OkObjectResult ObterTodos([FromQuery] string? nome)
        {
            var usuarios = _repositorioUsuario.ObterTodos(nome);
            return Ok(usuarios);
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        public OkObjectResult ObterPorId (int id)
        {
            var usuario = _repositorioUsuario.ObterPorId(id);
            return Ok(usuario);
        }

        [HttpPost("criar-usuario")]
        public CreatedResult Criar([FromBody] Usuario usuario)
        {
            _repositorioUsuario.Criar(usuario);
            return Created("criar-usuario", usuario);
        }

        [HttpDelete("remover-usuario/{id}")]
        public NoContentResult Remover (int id)
        {
            _repositorioUsuario.Remover(id);
            return NoContent();
        }

        [HttpPut("editar-usuario/{id}")]
        public NoContentResult Editar ([FromBody] Usuario usuario, int id)
        {
            _repositorioUsuario.Editar(usuario, id);
            return NoContent();
        }
    }
}