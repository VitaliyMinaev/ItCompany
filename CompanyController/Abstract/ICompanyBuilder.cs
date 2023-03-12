using Domain.Company;
using Domain.Company.Abstract;

namespace CompanyController.Abstract;

public interface ICompanyBuilder
{
    Company Build();
    void SetCompanyName(string name);
    void AddLogger(IFormLogger logger);
    IDepartment CreateDepartmentAndAddToCompany(string departmentName);
}