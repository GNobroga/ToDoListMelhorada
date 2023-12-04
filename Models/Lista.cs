using System.ComponentModel.DataAnnotations;

namespace to_do_list.Models;

public class Lista 
{
    public int Id { get; set; }

    [Display(Name = "Título")]
    [MinLength(5, ErrorMessage = "O {0} precisa ter no mínimo 5 caracteres")]
    public string Title { get; set; }

    public string? UserId { get; set; }
    
    public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}