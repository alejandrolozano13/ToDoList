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
    }
}
