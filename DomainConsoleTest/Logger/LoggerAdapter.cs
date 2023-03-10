using Microsoft.Extensions.Logging;
using ILogger = Domain.Common.Abstract.ILogger;

namespace DomainConsoleTest.Logger;

public class LoggerAdapter : ILogger
{
    private readonly Microsoft.Extensions.Logging.ILogger<LoggerAdapter> _logger;
    public LoggerAdapter(Microsoft.Extensions.Logging.ILogger<LoggerAdapter> logger)
    {
        _logger = logger;
    }
    
    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogError(string message)
    {
        _logger.LogError(message);
    }
}