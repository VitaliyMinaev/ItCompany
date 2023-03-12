using ItCompany.UI.Models.Abstract;

namespace ItCompany.UI.Models;

public class ProjectViewModel : IViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly Deadline { get; set; }
    public int CountOfIteration { get; set;  }
    public int TotalPrice { get; set; }
    public string Status { get; set; }
    public ClientViewModel? ProjectOwner { get; set; }

    public string GetAllDataInStringFormat()
    {
        return $"Id: {Id}\nName: {Name}\nDeadline: {Deadline}\nCount of iterations: {CountOfIteration}\n" +
            $"Total price: {TotalPrice}\nStatus: {Status}\nProject owner name: {ProjectOwner?.Name}";
    }
}
