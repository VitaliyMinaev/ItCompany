namespace ItCompany.UI.Models;

public class CompanyViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ClientViewModel> Clients { get; set; }
    public List<ProjectViewModel> Projects { get; set; }
    public List<DepartmentViewModel> Departments { get; set; }
}