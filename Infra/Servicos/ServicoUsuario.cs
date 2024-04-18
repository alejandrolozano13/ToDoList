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

        public void Criar(Usuario objeto)
        {
            _conexao.Add(objeto);
            _conexao.SaveChanges();
        }

        public void Editar(Usuario objeto, int id)
        {
            var usuario = ObterPorId(id);
            
            usuario.Nome = objeto.Nome;
            usuario.Email = objeto.Email;
            usuario.Senha = objeto.Senha;
            usuario.Tarefas = objeto.Tarefas;

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