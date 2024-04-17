using System.ComponentModel;

namespace Dominio.Enumeradores
{
    public enum StatusEnum
    {
        [Description("Em andamento")]
        EmAndamento = 0,

        [Description("A fazer")]
        AFazer = 1,

        [Description("Fechado")]
        Fechado = 2,

        [Description("Concluido")]
        Concluido = 3
    }
}