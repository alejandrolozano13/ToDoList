namespace Dominio.InterfaceModel
{
    public interface IModelRepositorio <T> where T : class
    {
        void Criar(T modelo);
        void Editar(T modelo, string id);
        void Remover(string id);
        T ObterPorId(string id);
        List<T> ObterTodos(string? nome);
    }
}