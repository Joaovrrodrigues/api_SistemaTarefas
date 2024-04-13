using SistemaTarefas1.Enums;

namespace SistemaTarefas1.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }  
        public StatusTarefa Status { get; set; } 

    }
}
