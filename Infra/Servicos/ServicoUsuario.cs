using Dominio.InterfaceModel;
using Dominio.Modelos;
using Infra.Dados;

namespace Infra.Servicos
{
    public class ServicoUsuario : IModelRepositorio<Usuario>
    {
        private readonly AppDbContext _conexao;

        public ServicoUsuario(AppDbContext conexao)
        {
            _conexao = conexao;
        }

        public T Criar<T>(object objeto)
        {
            throw new NotImplementedException();
        }

        public T Editar<T>(object objeto)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(object objeto)
        {
            throw new NotImplementedException();
        }

        public T Remover<T>(object objeto)
        {
            throw new NotImplementedException();
        }
    }
}
