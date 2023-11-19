using System.ComponentModel.DataAnnotations;

namespace HealtTrack.Models
{
    public class TodoItemViewModel
    {
        
        public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }

    public bool Concluido { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
