namespace ItCompany.UI.Models;

public class ClientViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Money { get; set; }
    public List<ProjectViewModel>? Projects { get; set; }
}