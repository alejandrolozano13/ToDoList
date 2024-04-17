namespace Dominio.InterfaceModel
{
    public interface IModelRepositorio <T>
    {
        T Criar<T>(object objeto);
        T Editar<T>(object objeto);
        T Remover<T>(object objeto);
        T ObterPorId(object objeto);
    }
}
