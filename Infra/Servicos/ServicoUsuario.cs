using Dominio.Interfaces;
using Dominio.Modelos;
using FluentValidation;
using Infra.Dados;

namespace Infra.Servicos
{
    public class ServicoUsuario : IUsuario
    {
        private readonly AppDbContext _conexao;
        private readonly IValidator<Usuario> _validador;

        public ServicoUsuario(AppDbContext conexao, IValidator<Usuario> validador)
        {
            _conexao = conexao;
            _validador = validador;
        }

        public void Criar(Usuario usuario)
        {
            var resultado = _validador.Validate(usuario);
            
            if (!resultado.IsValid)
            {
                throw new Exception(resultado.ToString());
            }

            _conexao.Add(usuario);
            _conexao.SaveChanges();
        }

        public void Editar(Usuario usuario, int id)
        {
            var usuarioDoBanco = ObterPorId(id);

            var resultado = _validador.Validate(usuario);

            if (!resultado.IsValid)
            {
                usuarioDoBanco.Nome = usuario.Nome;
                usuarioDoBanco.Email = usuario.Email;
                usuarioDoBanco.Senha = usuario.Senha;
                usuarioDoBanco.Tarefas = usuario.Tarefas;
            }

            _conexao.SaveChanges();
        }

        public Usuario ObterPorId(int id)
        {
            return _conexao.Usuarios.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Não foi possivel encontrar o usuario");
        }

        public List<Usuario> ObterTodos(string? nome)
        {
            return _conexao.Usuarios.ToList();
        }

        public void Remover(int id)
        {
            var usuario = ObterPorId(id);
            _conexao.Remove(usuario);
            _conexao.SaveChanges();
        }
    }
}