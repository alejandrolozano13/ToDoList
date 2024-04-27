using Dominio.Enumeradores;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Tarefas
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string UsuarioId { get; set; }
        //[JsonIgnore]
        //public Usuario? Usuario { get; set; }
    }
}