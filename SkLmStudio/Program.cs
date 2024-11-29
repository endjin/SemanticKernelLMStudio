using Microsoft.Extensions.DependencyInjection;

using SkLmStudio.Commands;
using SkLmStudio.Infrastructure;
using SkLmStudio.Infrastructure.Injection;

using Spectre.Console.Cli;

namespace SkLmStudio;

public static class Program
{
    public static Task<int> Main(string[] args)
    {
        ServiceCollection registrations = new();
        registrations.ConfigureDependencies();

        TypeRegistrar registrar = new(registrations);
        CommandApp app = new(registrar);

        app.Configure(config =>
        {
            config.Settings.PropagateExceptions = false;
            config.CaseSensitivity(CaseSensitivity.None);
            config.SetApplicationName("sk-llm-studio");
        });

        app.SetDefaultCommand<ChatCommand>();

        return app.RunAsync(args);
    }
}
