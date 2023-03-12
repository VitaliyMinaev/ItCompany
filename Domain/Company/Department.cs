using System.Collections;
using Domain.Common.Abstract;
using Domain.Company.Abstract;
using Domain.Common;

namespace Domain.Company;

public class Department : BaseDomainObject, IDepartment
{
    private readonly object balanceLock = new object();

    private const int SleepTimeInMs = 5000;

    private List<BaseEmployeeCommand> _commands;
    private CompanyProject? _project;
    public CompanyProject Project
    {
        get
        {
            return _project;
        }
    }
    public string Title { get; private set; }
    private ILogger? _logger;
    private IMoneyWithdraw _moneyWithdraw;
    public Department(Guid id, string title, IMoneyWithdraw moneyWithdraw, CompanyProject? project = null) : base(id)
    {
        _project = project;
        Title = title;
        _moneyWithdraw = moneyWithdraw;

        _commands = new List<BaseEmployeeCommand>();
    }
    public Department(Guid id, string title, IMoneyWithdraw moneyWithdraw, List<BaseEmployeeCommand> commands, CompanyProject? project = null) : base(id)
    {
        Title = title;
        _moneyWithdraw = moneyWithdraw;
        _commands = commands;
        _project = project;
    }

    public void SetLogger(ILogger logger)
    {
        _logger = logger;
    }
    public void StartWorkOnProject()
    {
        if (_project == null)
            throw new InvalidOperationException("Can not start working. Project does not exist");

        int iterations = _project.CountOfIteration;

        for (int i = 0; i < iterations; i++)
        {
            // Take money
            var withdrawResult = _moneyWithdraw.WithdrawMoney(_project, _project.CalculatePricePerIteration());
            _logger?.LogInformation($"{_project.Title}: Price per iteration: {_project.CalculatePricePerIteration()}");
            if (withdrawResult == false)
            {
                _logger?.LogError($"{_project.Title}: Does not have money to continue!");
                return;
            }

            Thread.Sleep(SleepTimeInMs);

            double progress = _project.UpdateProgress();
            _logger?.LogInformation($"{_project.Title}: Current progress in project: {progress}");
        }

        _logger?.LogInformation($"Project: {_project.Title} has been done!");
    }
    
    public bool ReceiveProject(CompanyProject project)
    {
        if (CanReceiveProject() == false)
            return false;

        lock (project)
        {
            _project = project;
        }

        return true;
    }

    public bool AddCommand(BaseEmployeeCommand command)
    {
        lock(command)
        {
            _commands.Add(command);
        }
        return true;
    }

    public bool RemoveCommand(Guid id)
    {
        var exist = _commands.FirstOrDefault(x => x.Id == id);

        if (exist == null)
            return false;
        
        lock(exist)
        {
            return _commands.Remove(exist);
        }
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

    public bool HasProject(Guid projectId)
    {
        if (_project == null)
            return false;

        return _project.Id == projectId;
    }
}