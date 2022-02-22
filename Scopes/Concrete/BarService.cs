using interfaces;
using Microsoft.Extensions.Logging;

namespace concrete;

public class BarService : IBarService
{
    private readonly IFooService _fooService;
    private readonly ILogger<BarService> _logger;

    public BarService(IFooService fooService, ILoggerFactory loggerFactory)
    {
        _fooService = fooService;
         _logger = loggerFactory.CreateLogger<BarService>(); 
         _logger.LogWarning("Constructor of BarService invoked");
    }

    public void DoSomeRealWork()
    {
        
        for (int i = 0; i < 2; i++)
        {
            _fooService.DoThing(i);
        }
    }
}