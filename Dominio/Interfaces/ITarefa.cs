using Dominio.InterfaceModel;
using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface ITarefa : IModelRepositorio<Tarefas>
    {
        List<Tarefas> ObterPorUsuarioId(string id);
    }
}
