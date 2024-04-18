namespace Dominio.InterfaceModel
{
    public interface IModelRepositorio <T> where T : class
    {
        void Criar(T objeto);
        void Editar(T objeto);
        void Remover(T id);
        T ObterPorId(T id);
        List<T> ObterTodos(string? nome);
    }
}