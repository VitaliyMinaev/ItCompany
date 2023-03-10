using Domain.Common;
using Domain.Common.Abstract;

namespace Domain.Company;

public class CompanyProject : BaseDomainObject
{
    public string Title { get; private set; }
    public int ExpectedPrice { get; private set; }
    public DateOnly Deadline { get; private set; }
    
    public CompanyProject(Guid id, string title, int expectedPrice, DateOnly deadline) : base(id)
    {
        Title = title;
        ExpectedPrice = expectedPrice;
        Deadline = deadline;
    }

    public Complexity CalculateComplexity()
    {
        throw new NotImplementedException();
    }
}