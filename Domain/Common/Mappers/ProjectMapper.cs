using Domain.Client;
using Domain.Company;

namespace Domain.Common.Mappers;

public static class ProjectMapper
{
    public static CompanyProject ToCompanyProject(this ClientProject clientProject, Complexity complexity)
    {
        return new CompanyProject(clientProject.Id, clientProject.Title, clientProject.ExpectedPrice, 
            CompanyProject.CalculateIterations(clientProject.Deadline), clientProject.Deadline);
    }
}