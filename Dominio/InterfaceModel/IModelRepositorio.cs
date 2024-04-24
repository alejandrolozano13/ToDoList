namespace Dominio.InterfaceModel
{
    public interface IModelRepositorio <T> where T : class
    {
        void Criar(T modelo);
        void Editar(T modelo, int id);
        void Remover(int id);
        T ObterPorId(int id);
        List<T> ObterTodos(string? nome);
    }
}