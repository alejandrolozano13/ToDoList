using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validacoes
{
    public class ValidacaoTarefa : AbstractValidator<Tarefas>
    {
        public ValidacaoTarefa()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da tarefa é obrigatória.")
                .MaximumLength(250)
                .WithMessage("A descrição da tarefa deve ter no máximo 250 caracteres.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status da tarefa é obrigatório")
                .IsInEnum()
                .WithMessage("O status fornecido não corresponde aos status padrões.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da tarefa é obrigatório")
                .MaximumLength(100)
                .WithMessage("O nome da tarefa deve ter no máximo 100 caracteres.");

            RuleFor(x => x.DataInicial)
                .NotNull()
                .WithMessage("A data inicial da tarefa é obrigatória.")
                .Must(DataInicialDeveSerMaiorQueODiaAtual)
                .WithMessage("A data inicial tem que ser a partir do dia atual.");

            RuleFor(x => x.DataFinal)
                .NotNull()
                .WithMessage("A data final da tarefa é obrigatória")
                .Must((tarefa, dataFinal) => DataFinalDeveSerMaiorQueDataInicial(tarefa.DataInicial, dataFinal))
                .WithMessage("Data final tem que ser maior que a data inicial.");

            RuleFor(x => x.UsuarioId)
                .NotNull()
                .WithMessage("A tarefa tem que pertencer a algum usuario.");
        }

        private bool DataInicialDeveSerMaiorQueODiaAtual(DateTime dataInicial)
        {
            var resultado = DateTime.Compare(dataInicial, DateTime.Now);
            return resultado >= 0;
        }

        private bool DataFinalDeveSerMaiorQueDataInicial(DateTime dataInicial, DateTime dataFinal)
        {
            var resultado = DateTime.Compare(dataFinal, dataInicial);
            return resultado >= 0;
        }
    }
}