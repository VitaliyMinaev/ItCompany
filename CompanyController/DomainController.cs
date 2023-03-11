using CompanyController.Abstract;
using Domain.Client;
using Domain.Common.Abstract;
using Domain.Company;
using Domain.Company.Abstract;

namespace CompanyController;

public class DomainController : IController
{
    private readonly ILogger _logger;

    private int _companyCount;
    private int _departmentCount;
    private int _usernameCount;
    private int _projectCount;
    public DomainController(ILogger logger)
    {
        _logger = logger;   

        _companyCount = 0;
        _departmentCount = 0;
        _usernameCount = 0;
        _projectCount = 0;
    }

    public IEnumerable<Client> ConfigureClients(int countOfClients, BaseCompany companyToBind)
    {
        for (int i = 0; i < countOfClients; i++)
        {
            var client = new Client(companyToBind, Guid.NewGuid(), $"User #{_usernameCount++}"
                , Random.Shared.Next(20000, 50000));

            client.OrderProject(new ClientProject(Guid.NewGuid(), $"Project #{_projectCount++}", 
                Random.Shared.Next(2200, 6700), DateOnly.FromDateTime(DateTime.Now.AddDays(Random.Shared.Next(14, 141)))));

            yield return new Client(companyToBind, Guid.NewGuid(), $"User #{_usernameCount++}"
                , Random.Shared.Next(20000, 50000));
        }
    }

    public BaseCompany ConfigureCompany()
    {
        var _companyBuilder = new CompanyBuilder();

        _companyBuilder.SetCompanyName($"Company: #{_companyCount++}");
        for (int i = 0; i < 5; i++)
        {
            _companyBuilder.CreateDepartmentAndAddToCompany($"Department #{_departmentCount++}");
        }

        _companyBuilder.AddLogger(_logger);
        
        return _companyBuilder.Build();
    }

    public void StartProcess(BaseCompany company, Guid projectId)
    {
        company.StartWorkOnProject(projectId);
    }
}
