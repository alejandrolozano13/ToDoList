using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Usuario
    {
        public Usuario()
        {
            Tarefas = new Collection<Tarefas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [JsonIgnore]
        public ICollection<Tarefas>? Tarefas { get; set; }
    }
}