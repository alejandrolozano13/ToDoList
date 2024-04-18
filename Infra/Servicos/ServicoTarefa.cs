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

        public void Criar(Tarefas objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(Tarefas objeto, int id)
        {
            throw new NotImplementedException();
        }

        public Tarefas ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarefas> ObterTodos(string? nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}