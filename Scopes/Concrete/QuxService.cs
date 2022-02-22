using interfaces;
using Microsoft.Extensions.Logging;

namespace concrete;

public class QuxService : IQuxService
{
    
  
    private readonly ILogger<BarService> _logger;
    private readonly string guid = Guid.NewGuid().ToString();

    public QuxService(ILoggerFactory loggerFactory)
    {
     

        _logger = loggerFactory.CreateLogger<BarService>(); 
        _logger.LogWarning($"Constructor of QuxService invoked Id={guid}");
    }

    public void DoSomeOtherThing(int number)
    {
        _logger.LogInformation($"Qux is collecting some fruits. My Id = {this.guid}");
    }
}