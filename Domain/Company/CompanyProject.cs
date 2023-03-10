using Domain.Common;
using Domain.Common.Abstract;

namespace Domain.Company;

public class CompanyProject : BaseDomainObject
{
    private const int AcceptableCountOfIterations = 6;
    public string Title { get; private set; }
    public DateOnly Deadline { get; private set; }
    public int CountOfIteration { get; }
    public int PricePerIteration { get; }
    public Complexity Complexity { get; }
    private double _progress;
    public CompanyProject(Guid id, string title, int expectedPrice, int countOfIteration, DateOnly deadline) : base(id)
    {
        Title = title;
        Complexity = EvaluateComplexity(deadline);
        PricePerIteration = CalculatePricePerIteration(expectedPrice, Complexity, deadline);
        CountOfIteration = CalculateIterations(deadline);
        Deadline = deadline;

        _progress = 0;
    }

    public double UpdateProgress()
    {
        if (_progress + CalculateProgressForStep(CountOfIteration) >= 100)
        {
            _progress = 100;
            return _progress;
        }
        
        _progress += CalculateProgressForStep(CountOfIteration);
        return _progress;
    }

    private double CalculateProgressForStep(int countOfIteration)
    {
        return (double)100 / countOfIteration;
    }

    public static int CalculateIterations(DateOnly deadline)
    {
        var currentDateTime = DateTime.Now;
        int counterOfIterations = 0;
        while (DateOnly.FromDateTime(currentDateTime) < deadline)
        {
            currentDateTime = currentDateTime.AddDays(7);
            counterOfIterations += 1;
        }

        return counterOfIterations;
    }
    public static int CalculatePricePerIteration(int expectedPrice, Complexity complexity, DateOnly deadline)
    {
        double coefficient = CalculateCoefficient(deadline);

        int lowerPrice = (int)(expectedPrice - (expectedPrice * coefficient));
        int upperPrice = (int)(expectedPrice + (expectedPrice * coefficient));

        if (complexity == Complexity.Easy)
        {
            return Random.Shared.Next(lowerPrice, expectedPrice);
        }
        else if (complexity == Complexity.Medium)
        {
            return Random.Shared.Next(lowerPrice, expectedPrice + 20);
        }
        else
        {
            return Random.Shared.Next(expectedPrice, upperPrice);
        }
    }
    public static double CalculateCoefficient(DateOnly deadline)
    {
        if (CalculateIterations(deadline) < AcceptableCountOfIterations)
        {
            return 0.8;
        }
        else
        {
            return 0.4;
        }
    }
    public static Complexity EvaluateComplexity(DateOnly deadline)
    {
        int daysLeft = deadline.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;

        if (daysLeft > 90)
            return Complexity.Easy;
        else if (daysLeft > 45)
            return Complexity.Medium;
        else
            return Complexity.Hard;
    }
}