using Domain.Common.Abstract;

namespace Domain.Client.Abstract;

public abstract class BaseClient : BaseDomainObject
{
    public string Username { get; protected set; }
    protected BaseClient(Guid id, string username) : base(id)
    {
        Username = username;
    }
    
    public virtual void ChangeUsername(string newUsername)
    {
        Username = newUsername;
    }
    public abstract bool OrderProject(ClientProject project);
}