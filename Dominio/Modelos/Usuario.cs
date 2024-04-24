using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Senha { get; set; }

        [JsonIgnore]
        public List<Tarefas>? Tarefas { get; set; }
    }
}