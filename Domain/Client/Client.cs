using System.Collections;
using Domain.Client.Abstract;
using Domain.Company.Abstract;

namespace Domain.Client;

public class Client : BaseClient, IEnumerable<ClientProject>
{
    private List<ClientProject> _projects;
    private readonly ICompanyRequestReceiver _company;
    
    public Client(ICompanyRequestReceiver company, Guid id, string username) : base(id, username)
    {
        _company = company;
        _projects = new List<ClientProject>();
    }

    public override bool OrderProject(ClientProject project)
    {
        var result = _company.ReceiveProject(project, this);

        if (result == false)
            return false;

        _projects.Add(project);
        return true;
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