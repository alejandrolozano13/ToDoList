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


    }
}