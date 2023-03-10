using Domain.Client;
using Domain.Client.Abstract;
using Domain.Common.Mappers;
using Domain.Company.Abstract;

namespace Domain.Company;

public class Company : BaseCompany
{
    private List<BaseClient> _clients;
    private List<CompanyProject> _projects;
    protected List<IDepartment> _departments;
    
    private readonly int _projectLimit;
    public Company(Guid id, string title, int projectLimit = 100) : base(id, title)
    {
        _clients = new List<BaseClient>();
        _projects = new List<CompanyProject>();
        _departments = new List<IDepartment>();
        
        _projectLimit = projectLimit;
    }
    
    public override bool ReceiveProject(ClientProject clientProject, BaseClient projectOwner)
    {
        if (CanAcceptProject() == false)
            return false;
        _clients.Add(projectOwner);
        
        var departmentToReceive = GetAvailableDepartment();
        if (departmentToReceive == null)
            throw new InvalidOperationException("There is no available departments");

        var project = clientProject.ToCompanyProject();
        departmentToReceive.ReceiveProject(project);
        // To do ...
        _projects.Add(project);
        
        return true;
    }

    protected virtual bool CanAcceptProject()
    {
        var exist = GetAvailableDepartment();

        if (exist == null)
            return false;

        return (_projects.Count + 1) < _projectLimit;
    }
    protected virtual IDepartment? GetAvailableDepartment()
    {
        return _departments.FirstOrDefault(x => x.CanReceiveProject() == true);
    }
}