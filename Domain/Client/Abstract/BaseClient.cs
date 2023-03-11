using Domain.Common.Abstract;

namespace Domain.Client.Abstract;

public abstract class BaseClient : BaseDomainObject
{
    public string Username { get; protected set; }
    public double Money { get; private set; }
    protected BaseClient(Guid id, string username, double money) : base(id)
    {
        Username = username;
        Money = money;
    }

    public virtual void ChangeUsername(string newUsername)
    {
        Username = newUsername;
    }
    public abstract bool OrderProject(ClientProject project);
    public virtual void AddMoney(double money)
    {
        if (money < 0)
            throw new InvalidOperationException();
        Money += money;
    }
    public virtual bool WithdrawMoney(double money)
    {
        if(Money - money <= 0)
        {
            return false;
        }

        Money -= money;
        return true;
    }
}