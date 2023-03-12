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
        departmentsListBox.Items.Add(new DepartmentViewModel { Id = Guid.NewGuid(), Title = "Department #1", CountOfCommands = 3 });

        _currentCompany = _controller.ConfigureCompany();
        _currentCompany = _controller.ConfigureClients(1, _currentCompany);
    }

    private void clientsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (clientsListBox.SelectedItems.Count == 0)
            return;

        var selectedObject = (string)clientsListBox.SelectedItems[0];
        MessageBox.Show(selectedObject.ToString());
    }

    private void projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<ProjectViewModel>(projectsListBox);
    }

    private void departmentsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySelectedItemFromListBox<DepartmentViewModel>(departmentsListBox);
    }

    private void DisplaySelectedItemFromListBox<T>(ListBox listBox)
        where T : IViewModel
    {
        if (listBox.SelectedItems.Count == 0)
            return;

        var selected = (T)departmentsListBox.SelectedItems[0];
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

        foreach (var thread in threads)
        {
            thread.Start();
        }

        MessageBox.Show("Started!");
    }

    private void loadDataButton_Click(object sender, EventArgs e)
    {

    }
}