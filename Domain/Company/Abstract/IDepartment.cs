namespace Domain.Company.Abstract;

public interface IDepartment : IEnumerable<BaseEmployeeCommand>
{
    void StartWorkOnProject();
    bool ReceiveProject(CompanyProject project);
    
    bool AddCommand(BaseEmployeeCommand command);
    bool RemoveCommand(Guid id);

    bool HasProject(Guid projectId);
    bool CanReceiveProject();
}