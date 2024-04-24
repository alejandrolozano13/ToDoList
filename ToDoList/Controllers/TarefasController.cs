using Dominio.InterfaceModel;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IModelRepositorio<Tarefas> _repositorioTarefa;

        public TarefasController(IModelRepositorio<Tarefas> repositorioTarefa)
        {
            _repositorioTarefa = repositorioTarefa;
        }

        [HttpGet("obter-todas-as-tarefas")]
        public OkObjectResult ObterTodasAsTarefas([FromQuery] string? nome)
        {
            var tarefas = _repositorioTarefa.ObterTodos(nome);
            return Ok(tarefas);
        }

        [HttpGet("obter-por-id/{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var tarefa = _repositorioTarefa.ObterPorId(id);
            return Ok(tarefa);
        }

        [HttpPost("adicionar-tarefa")]
        public CreatedResult Criar([FromBody] Tarefas tarefas)
        {
            _repositorioTarefa.Criar(tarefas);
            return Created();
        }

        [HttpPut("editar-tarefa/{id}")]
        public NoContentResult Editar([FromBody] Tarefas tarefas, int id)
        {
            _repositorioTarefa.Editar(tarefas, id);
            return NoContent();
        }

        [HttpDelete("Remover-tarefa/{id}")]
        public NoContentResult Remover(int id)
        {
            _repositorioTarefa.Remover(id);
            return NoContent();
        }
    }
}