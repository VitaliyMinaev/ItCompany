using ItCompany.UI.Models.Abstract;

namespace ItCompany.UI.Models;

public class DepartmentViewModel : IViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int CountOfCommands { get; set; }
    public ProjectViewModel? Project { get; set; }
    public override string ToString()
    {
        return Title;
    }
    public string GetAllDataInStringFormat()
    {
        return $"Id: {Id}\nTitle: {Title}\nCount of commands: {CountOfCommands}\n";
    }
}
