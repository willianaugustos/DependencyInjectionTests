using interfaces;
using Microsoft.Extensions.Logging;

namespace concrete;

public class BazService : IBazService
{

    private readonly ILogger<BarService> _logger;
    private readonly IQuxService _quxService;

    private readonly string guid = Guid.NewGuid().ToString();
    public BazService(ILoggerFactory loggerFactory, IQuxService quxService)
    {
        _quxService = quxService;

         _logger = loggerFactory.CreateLogger<BarService>(); 
         _logger.LogWarning("Constructor of BazService invoked");
    }

    public void DoThatImportantThing(int number)
    {
        _logger.LogInformation($"Working on something really important here. My id = {guid}");

        _quxService.DoSomeOtherThing(1);
    }
}