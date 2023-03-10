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
    public abstract bool ReceiveProject(ClientProject clientProject, BaseClient projectOwner);
}