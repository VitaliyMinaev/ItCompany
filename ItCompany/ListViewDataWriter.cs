using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCompany.UI;

class Tester
{
    public string Title { get; set; }
    public Tester()
    {
        Title = "Some value: " + Random.Shared.Next(0, 255);
    }

    public override string ToString()
    {
        return Title; ;
    }
}


public class ListViewDataWriter
{
    private readonly ListBox _listView;
    public ListViewDataWriter(ListBox listView)
    {
        _listView = listView;
    }

    public void HandleWriteRequest(string message)
    {
        _listView.Invoke((MethodInvoker)delegate
        {
            _listView.Items.Add(message);
        });
    }
}
