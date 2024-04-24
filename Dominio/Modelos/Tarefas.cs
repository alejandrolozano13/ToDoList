using Dominio.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    //public class Tarefas
    //{
    //    public int Id { get; set; }
    //    public int UsuarioId { get; set; }
    //    public virtual Usuario Usuario { get; set; }
    //    public string Descricao { get; set; }
    //    public StatusEnum Status { get; set; }
    //    public string Nome {  get; set; }
    //    public DateTime DataInicial { get; set; }
    //    public DateTime DataFinal { get; set; }
    //}

    public class Tarefas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}