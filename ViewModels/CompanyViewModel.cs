﻿using ItCompany.UI.Models.Abstract;

namespace ItCompany.UI.Models;

public class CompanyViewModel : IViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ClientViewModel> Clients { get; set; }
    public List<ProjectViewModel> Projects { get; set; }
    public List<DepartmentViewModel> Departments { get; set; }

    public override string ToString()
    {
        return Name;
    }
    public string GetAllDataInStringFormat()
    {
        return $"Id: {Id}\nName: {Name}";
    }
}