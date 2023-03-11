using System.Collections;
using Domain.Client.Abstract;
using Domain.Company.Abstract;

namespace Domain.Client;

public class Client : BaseClient, IEnumerable<ClientProject>
{
    private List<ClientProject> _projects;
    private readonly ICompanyRequestReceiver _company;
    
    public Client(ICompanyRequestReceiver company, Guid id, string username, double money) : base(id, username, money)
    {
        _company = company;
        _projects = new List<ClientProject>();
    }

    public override Guid OrderProject(ClientProject project)
    {
        var projectId = _company.ReceiveProject(project, this);

        if (projectId == Guid.Empty)
            return Guid.Empty;

        _projects.Add(project);
        return projectId;
    }

    public IEnumerator<ClientProject> GetEnumerator()
    {
        return _projects.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}