using Domain.Company;
using Domain.Company.Abstract;
using ItCompany.UI.Models;

namespace Mappers;

public static class DepartmentMapper
{
    public static Department ToDomain(this DepartmentViewModel model, IMoneyWithdraw moneyWithdraw, ICompanyRequestReceiver receiver)
    {
        return new Department(model.Id, model.Title, moneyWithdraw, model.Project.ToDomain(receiver));
    }
    public static DepartmentViewModel ToModel(this Department domain)
    {
        return new DepartmentViewModel
        {
            Id = domain.Id,
            Title = domain.Title,
            CountOfCommands = domain.Count(),
            Project = domain.Project?.ToModel()
        };
    }
}
