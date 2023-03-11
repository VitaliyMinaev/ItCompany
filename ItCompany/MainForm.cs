namespace ItCompany.UI;

public partial class MainForm : Form
{
    private Action<string> _action;
    private ListViewDataWriter _writer;
    public MainForm()
    {
        InitializeComponent();

        _writer = new ListViewDataWriter(actionsListBox);
        _action += _writer.HandleWriteRequest;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        clientsListBox.Items.Add(new Tester());
    }

    private void testButton_Click(object sender, EventArgs e)
    {
        var thread = new Thread(() =>
        {
            for(int i = 0; i < 100; ++i)
            {
                _action?.Invoke("Random value: " + Random.Shared.Next(1, 255));
                Thread.Sleep(3000);
            }
        });
        thread.Start();
    }

    private void clientsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (clientsListBox.SelectedItems.Count == 0)
            return;

        var selectedObject = (Tester)clientsListBox.SelectedItems[0];
        MessageBox.Show(selectedObject.ToString());
    }
}