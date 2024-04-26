using Dominio.Interfaces;
using Dominio.Modelos;
using FluentValidation;
using Infra.Dados;

namespace Infra.Servicos
{
    public class ServicoTarefa : ITarefa
    {
        private readonly AppDbContext _conexao;
        private readonly IValidator<Tarefas> _validador;

        public ServicoTarefa(AppDbContext conexao, IValidator<Tarefas> validador)
        {
            _conexao = conexao;
            _validador = validador;
        }

        public void Criar(Tarefas tarefa)
        {
            var resultado = _validador.Validate(tarefa);

            if(!resultado.IsValid)
            {
                throw new Exception(resultado.ToString());
            }

            _conexao.Add(tarefa);
            _conexao.SaveChanges();
        }

        public void Editar(Tarefas tarefa, int id)
        {
            var tarefaDoBanco = ObterPorId(id);

            var resultado = _validador.Validate(tarefa);

            if(!resultado.IsValid)
            {
                tarefaDoBanco.UsuarioId = tarefa.UsuarioId;
                tarefaDoBanco.Descricao = tarefa.Descricao;
                tarefaDoBanco.Status = tarefa.Status;
                tarefaDoBanco.Nome = tarefa.Nome;
                tarefaDoBanco.DataInicial = tarefa.DataInicial;
                tarefaDoBanco.DataFinal = tarefa.DataFinal;
            }

            _conexao.SaveChanges();
        }

        public Tarefas ObterPorId(int id)
        {
            return _conexao.Tarefas.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Tarefa não encontrada.");
        }

        public List<Tarefas> ObterPorUsuarioId(int id)
        {
            return _conexao.Tarefas.Where(x => x.UsuarioId == id).ToList()
                ?? throw new Exception("Tarefa não encontrada no usuario informado");
        }

        public List<Tarefas> ObterTodos(string? nome)
        {
            return _conexao.Tarefas.ToList();
        }

        public void Remover(int id)
        {
            var tarefa = ObterPorId(id);
            _conexao.Remove(tarefa);
            _conexao.SaveChanges();
        }
    }
}