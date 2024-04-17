using Dominio.InterfaceModel;
using Dominio.Modelos;
using Infra.Dados;

namespace Infra.Servicos
{
    public class ServicoTarefa : IModelRepositorio<Tarefas>
    {
        private readonly AppDbContext _conexao;

        public ServicoTarefa(AppDbContext conexao)
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

        public Tarefas ObterPorId(object objeto)
        {
            throw new NotImplementedException();
        }

        public T Remover<T>(object objeto)
        {
            throw new NotImplementedException();
        }
    }
}
