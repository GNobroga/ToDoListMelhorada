using to_do_list.Models;

namespace to_do_list.ViewModels;

public class ShowListViewModel 
{
    public int SelectedListId { get; set; }

    public Lista? SelectedList { get; set; }

    public List<Lista> Listas { get; set; } = new List<Lista>();
}