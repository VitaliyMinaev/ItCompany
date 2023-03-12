using CompanyController;
using CompanyController.Abstract;
using ItCompany.UI.Models;
using ItCompany.UI.Models.Abstract;

namespace ItCompany.UI;

public partial class MainForm : Form
{
    private Action<string> _action;
    private ListViewDataWriter _writer;
    private readonly IController _controller;
    private readonly ListBoxLogger _logger;
    private CompanyViewModel _currentCompany;

    public MainForm()
    {
        InitializeComponent();

        _writer = new ListViewDataWriter(actionsListBox);
        _action += _writer.HandleWriteRequest;

        _currentCompany = new CompanyViewModel();

        _logger = new ListBoxLogger(actionsListBox);
        _controller = new DomainController(_logger);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        _currentCompany = _controller.ConfigureCompany();
        _currentCompany = _controller.ConfigureClients(1, _currentCompany);
    }

    private void clientsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<ClientViewModel>((ListBox)sender);
    }

    private void projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<ProjectViewModel>(projectsListBox);
    }

    private void departmentsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<DepartmentViewModel>((ListBox)sender);
    }

    private void DisplaySelectedItemFromListBox<T>(ListBox listBox)
        where T : IViewModel
    {
        if (listBox.SelectedItems.Count == 0)
            return;

        var selected = (T)listBox.SelectedItems[0];
        MessageBox.Show(selected.GetAllDataInStringFormat());
    }

    private void state1Button_Click(object sender, EventArgs e)
    {
        var threads = new List<Thread>();

        foreach (var item in _currentCompany.Projects)
        {
            threads.Add(new Thread(() =>
            {
                try
                {
                    _controller.StartProcess(_currentCompany, item.Id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }));
        }

        StartThreads(threads);

        MessageBox.Show("State 1 started!");
    }

    private void LoadDataToListBoxes(CompanyViewModel company, List<DepartmentViewModel> departments, 
        List<ClientViewModel> clients, List<ProjectViewModel> projects)
    {
        LoadDataToListBox<CompanyViewModel>(companiesListBox, new List<CompanyViewModel>() { company });
        LoadDataToListBox<DepartmentViewModel>(departmentsListBox, departments);
        LoadDataToListBox<ClientViewModel>(clientsListBox, clients);
        LoadDataToListBox<ProjectViewModel>(projectsListBox, projects);
    }

    private void LoadDataToListBox<T>(ListBox listBox, List<T> collection)
    {
        listBox.Invoke(() =>
        {
            listBox.Items.Clear();

            foreach (var item in collection)
            {
                listBox.Items.Add(item);
            }
        });
    }

    private void loadDataButton_Click(object sender, EventArgs e)
    {
        LoadDataToListBoxes(_currentCompany, _currentCompany.Departments, _currentCompany.Clients, _currentCompany.Projects);
    }

    private void companiesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<CompanyViewModel>((ListBox)sender);
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        var company = _controller.GetCurrentCompanyState(_currentCompany.Id);

        if (company == null)
            return;

        _currentCompany = company;
        LoadDataToListBoxes(_currentCompany, _currentCompany.Departments, _currentCompany.Clients, _currentCompany.Projects);
    }

    private void state2Button_Click(object sender, EventArgs e)
    {
        var company = _controller.CreateAndOrderProjects(_currentCompany.Id,
                Random.Shared.Next(1, 4));

        if (company == null)
            return;

        _currentCompany = company;

        var threads = new List<Thread>();
        CreateProcessThreadAndAddToCollection(threads);
        StartThreads(threads);

        MessageBox.Show("State 2 started!");
    }

    private static void StartThreads(List<Thread> threads)
    {
        foreach (var thread in threads)
        {
            thread.Start();
        }
    }

    private void CreateProcessThreadAndAddToCollection(List<Thread> threads)
    {
        foreach (var item in _currentCompany.Projects.Where(x => x.Status == "Todo"))
        {
            threads.Add(new Thread(() =>
            {
                try
                {
                    _controller.StartProcess(_currentCompany, item.Id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }));
        }
    }

    private void state3Button_Click(object sender, EventArgs e)
    {
        _currentCompany = _controller.ConfigureClients(2, _currentCompany);

        var threads = new List<Thread>();
        CreateProcessThreadAndAddToCollection(threads);
        StartThreads(threads);

        MessageBox.Show("State 3 started!");
    }
}