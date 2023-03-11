using Domain.Client;
using Domain.Client.Abstract;

namespace Domain.Company.Abstract;

public interface ICompanyRequestReceiver
{
    Guid ReceiveProject(ClientProject clientProject, BaseClient projectOwner);
}