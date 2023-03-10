using System.Collections;
using Domain.Common.Abstract;
using Domain.Company.Abstract;
using System.Linq;

namespace Domain.Company;

public class Department : BaseDomainObject, IDepartment
{
    private List<BaseEmployeeCommand> _commands;
    private CompanyProject? _project;
    
    public Department(Guid id, CompanyProject? project = null) : base(id)
    {
        _project = project;
        _commands = new List<BaseEmployeeCommand>();
    }
    public Department(Guid id, List<BaseEmployeeCommand> commands, CompanyProject? project = null) : base(id)
    {
        _project = project;
        _commands = commands;
    }

    public void StartWorkOnProject()
    {
        if (_project == null)
            throw new InvalidOperationException("Can not start working on null project");

        throw new NotImplementedException();
    }
    
    public bool ReceiveProject(CompanyProject project)
    {
        if (_project != null)
            return false;

        _project = project;
        return true;
    }

    public bool AddCommand(BaseEmployeeCommand command)
    {
        _commands.Add(command);
        return true;
    }

    public bool RemoveCommand(Guid id)
    {
        var exist = _commands.FirstOrDefault(x => x.Id == id);

        if (exist == null)
            return false;
        
        return _commands.Remove(exist);
    }

    public bool CanReceiveProject()
    {
        return _project == null;
    }

    public IEnumerator<BaseEmployeeCommand> GetEnumerator()
    {
        return _commands.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}