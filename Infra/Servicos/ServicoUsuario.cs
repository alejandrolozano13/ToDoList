using Dominio.Interfaces;
using Dominio.Modelos;
using FluentValidation;
using Infra.Dados;
using Infra.MongoDbRepository.Configuracoes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infra.Servicos
{
    public class ServicoUsuario : IUsuario
    {
        private readonly AppDbContext _conexao;
        private readonly IValidator<Usuario> _validador;
        private readonly IMongoCollection<Usuario> _conexaoMongoDb;

        public ServicoUsuario(AppDbContext conexao, IValidator<Usuario> validador, 
            IOptions<DatabaseSettings> databaseSettings)
        {
            _conexao = conexao;
            _validador = validador;

            // Instanciando a conexão com o Mongo DB:

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _conexaoMongoDb = mongoDb.GetCollection<Usuario>(databaseSettings.Value.CollectionName);
        }

        public async void Criar(Usuario usuario)
        {
            var resultado = _validador.Validate(usuario);
            
            if (!resultado.IsValid)
            {
                throw new Exception(resultado.ToString());
            }

            _conexaoMongoDb.InsertOneAsync(usuario);

            //_conexao.Add(usuario);
            //_conexao.SaveChanges();
        }

        public void Editar(Usuario usuario, string id)
        {
            //var usuarioDoBanco = ObterPorId(id);

            var resultado = _validador.Validate(usuario);

            //if (!resultado.IsValid)
            //{
            //    usuarioDoBanco.Nome = usuario.Nome;
            //    usuarioDoBanco.Email = usuario.Email;
            //    usuarioDoBanco.Senha = usuario.Senha;
            //    usuarioDoBanco.Tarefas = usuario.Tarefas;
            //}

            //_conexao.SaveChanges();
        }

        public Usuario ObterPorId(string id)
        {
            return _conexaoMongoDb.Find(x => x.Id == id).FirstOrDefault();
            //return _conexao.Usuarios.FirstOrDefault(x => x.Id == id)
            //    ?? throw new Exception("Não foi possivel encontrar o usuario");
        }

        public List<Usuario> ObterTodos(string? nome)
        {
            //return _conexao.Usuarios.ToList();
            return _conexaoMongoDb.Find(x => true).ToList();
        }

        public void Remover(string id)
        {
            //var usuario = ObterPorId(id);
            //_conexao.Remove(usuario);
            //_conexao.SaveChanges();
        }
    }
}