using Dominio.InterfaceModel;
using Dominio.Modelos;
using Infra.Dados;
using Microsoft.EntityFrameworkCore;

namespace Infra.Servicos
{
    public class ServicoUsuario : IModelRepositorio<Usuario>
    {
        private readonly AppDbContext _conexao;

        public ServicoUsuario(AppDbContext conexao)
        {
            _conexao = conexao;
        }

        public void Criar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(Usuario id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodos(string? nome)
        {
            return _conexao.Usuarios.ToList();
        }

        public void Remover(Usuario id)
        {
            throw new NotImplementedException();
        }
    }
}
