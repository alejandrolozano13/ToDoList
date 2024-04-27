using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefa _repositorioTarefa;

        public TarefasController(ITarefa repositorioTarefa)
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
        public OkObjectResult ObterPorId(string id)
        {
            var tarefa = _repositorioTarefa.ObterPorId(id);
            return Ok(tarefa);
        }

        [HttpGet("obter-por-usuarioId/{id}")]
        public OkObjectResult ObterPorUsuarioId(string id)
        {
            var tarefa = _repositorioTarefa.ObterPorUsuarioId(id);
            return Ok(tarefa);
        }

        [HttpPost("adicionar-tarefa")]
        public CreatedResult Criar([FromBody] Tarefas tarefas)
        {
            _repositorioTarefa.Criar(tarefas);
            return Created("adicionar-tarefa", tarefas);
        }

        [HttpPut("editar-tarefa/{id}")]
        public NoContentResult Editar([FromBody] Tarefas tarefas, string id)
        {
            _repositorioTarefa.Editar(tarefas, id);
            return NoContent();
        }

        [HttpDelete("remover-tarefa/{id}")]
        public NoContentResult Remover(string id)
        {
            _repositorioTarefa.Remover(id);
            return NoContent();
        }
    }
}