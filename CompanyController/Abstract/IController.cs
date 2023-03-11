using Domain.Client;
using Domain.Company.Abstract;

namespace CompanyController.Abstract;

public interface IController
{
    BaseCompany ConfigureCompany();
    IEnumerable<Client> ConfigureClients(int countOfClients, BaseCompany companyToBind);
    void StartProcess(BaseCompany company, Guid projectId);
}