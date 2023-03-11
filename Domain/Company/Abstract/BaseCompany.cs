using Domain.Client;
using Domain.Client.Abstract;
using Domain.Common.Abstract;

namespace Domain.Company.Abstract;

public abstract class BaseCompany : BaseDomainObject, ICompanyRequestReceiver
{
    public string Title { get; protected set; }
    public BaseCompany(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public virtual void ChangeCompanyTitle(string newTitle)
    {
        Title = newTitle;
    }
    public abstract Guid ReceiveProject(ClientProject clientProject, BaseClient projectOwner);
    public abstract void StartWorkOnProject(Guid projectId);
    public abstract void AddDepartment(IDepartment department);
    public abstract IEnumerable<CompanyProject> GetAllProjects();
}