using Domain.Client;
using Domain.Client.Abstract;

namespace Domain.Company.Abstract;

public interface ICompanyRequestReceiver
{
    bool ReceiveProject(ClientProject clientProject, BaseClient projectOwner);
}