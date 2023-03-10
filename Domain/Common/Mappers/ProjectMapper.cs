using Domain.Client;
using Domain.Company;

namespace Domain.Common.Mappers;

public static class ProjectMapper
{
    public static CompanyProject ToCompanyProject(this ClientProject clientProject)
    {
        return new CompanyProject(clientProject.Id, clientProject.Title, clientProject.ExpectedPrice, clientProject.Deadline);
    }
}