using Dominio.Enumeradores;

namespace Dominio.Modelos
{
    public class Tarefas
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public string Nome {  get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
