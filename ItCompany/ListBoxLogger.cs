using CompanyController.Abstract;

namespace ItCompany.UI;

internal class ListBoxLogger : IFormLogger
{
    private readonly ListBox _listView;
    public ListBoxLogger(ListBox listView)
    {
        _listView = listView;
    }

    public void LogError(string message)
    {
        _listView.Invoke((MethodInvoker)delegate
        {
            _listView.Items.Add($"Error: {message}");
        });
    }

    public void LogInformation(string message)
    {
        _listView.Invoke((MethodInvoker)delegate
        {
            _listView.Items.Add(message);
        });
    }
}