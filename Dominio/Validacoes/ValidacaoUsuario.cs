using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validacoes
{
    public class ValidacaoUsuario : AbstractValidator<Usuario>
    {
        public ValidacaoUsuario()
        {
            RuleFor(usuario => usuario.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuario é obrigatório.")
                .Length(2, 150)
                .WithMessage("O nome do usuario deve ter entre 2 e 150 caracteres.");

            RuleFor(usuario => usuario.Email)
                .NotEmpty()
                .WithMessage("O email do usuario é obrigatório.")
                .EmailAddress()
                .WithMessage("O email informado não é válido.");

            RuleFor(usuario => usuario.Senha)
                .NotEmpty()
                .WithMessage("A senha do usuario é obrigatória.")
                .Length(2, 20)
                .WithMessage("A senha do usuario deve ter entre 2 e 20 caracteres");
        }
    }
}
