using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using interfaces;
using concrete;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging( opt => opt.AddConsole())
            .AddSingleton<IFooService, FooService>()
            .AddSingleton<IBarService, BarService>()
            .AddSingleton<ILoggerFactory, LoggerFactory>()

            .AddScoped<IBazService, BazService>()
            .AddTransient<IQuxService, QuxService>()

            .BuildServiceProvider();

        var loggerFac = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFac.CreateLogger<Program>();
        logger.LogInformation("Log debug in action");

        //do the actual work here
        logger.LogWarning("Since BarService uses SingleTon Scope, you should see once the information of Constructor step.");
        var bar1 = serviceProvider.GetService<IBarService>();
        bar1.DoSomeRealWork();

        var bar2 = serviceProvider.GetService<IBarService>();
        bar2.DoSomeRealWork();


        logger.LogWarning("Since BazService uses 'Scoped' scope, you should see once the information of Constructor step.");
        var baz1 = serviceProvider.GetService<IBazService>();
        baz1.DoThatImportantThing(1);

        var baz2 = serviceProvider.GetService<IBazService>();
        baz2.DoThatImportantThing(1);

        // logger.LogWarning("Since QuxService uses 'Transient' scope, you should see twice the information of Constructor step.");
        // var qux1 = serviceProvider.GetService<IQuxService>();
        // qux1.DoSomeOtherThing(1);

        // var qux2 = serviceProvider.GetService<IQuxService>();
        // qux1.DoSomeOtherThing(1);
        
        //logger.LogDebug("All done!");
        

    }
}