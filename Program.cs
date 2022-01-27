using System.Reflection;
using Config;
using Discord;
using Discord.Interactions;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services;

class Program
{
    // main entry point
    static Task Main(string[] args) => new Program().MainAsync();

    private readonly DiscordSocketClient _client;
    private readonly InteractionService _interactions;
    private readonly IServiceProvider _services;
    private readonly ILogger<Program> _logger;
    private readonly Config.Options _options;

    private Program()
    {
        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers | GatewayIntents.GuildPresences,
        });

        _interactions = new InteractionService(_client, new InteractionServiceConfig
        {
            LogLevel = LogSeverity.Info,
            UseCompiledLambda = true,

        });

        // create service collection
        // create service provider
        _services = ConfigureServices(_client, _interactions);

        _options = _services.GetRequiredService<IOptions<Config.Options>>().Value;
        
        _logger = _services.GetRequiredService<ILogger<Program>>();

    }

    private static IServiceProvider ConfigureServices(DiscordSocketClient client, InteractionService interactions)
    {
        // build config
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var map = new ServiceCollection()
            // configure logging
            .AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            })
            // configure options
            .Configure<Config.Options>(configuration.GetSection("Options"))
            // add services
            // services.AddTransient<IBotExtension, MyBotExtension>();
            .AddSingleton(client)
            .AddSingleton(interactions)
            .AddSingleton<CommandHandler>();

        // There's an overload taking in a 'validateScopes' bool
        return map.BuildServiceProvider();
    }

    private async Task MainAsync()
    {

        _client.Log += LogAsync;
        _interactions.Log += LogAsync;
        _client.Ready += ReadyAsync;

        // Login and connect.
        await _client.LoginAsync(TokenType.Bot, _options.Credentials.Token);
        await _client.StartAsync();

        await _services.GetRequiredService<CommandHandler>().InitializeAsync();

        // Wait infinitely so your bot actually stays connected.
        await Task.Delay(Timeout.Infinite);
    }
    private Task LogAsync(LogMessage message)
    {

        switch (message.Severity)
        {
            case LogSeverity.Critical:
                _logger.LogCritical("{Message}\n{Source}\n\n{Exception}", message.Message, message.Source, message.Exception);
                break;
            case LogSeverity.Error:
                _logger.LogError("{Message}\n{Source}\n\n{Exception}", message.Message, message.Source, message.Exception);
                break;
            case LogSeverity.Warning:
                _logger.LogWarning("{Message}\n{Source}\n\n{Exception}", message.Message, message.Source, message.Exception);
                break;
            case LogSeverity.Info:
                _logger.LogInformation("{Message}", message.Message);
                break;
            case LogSeverity.Verbose:
                _logger.LogTrace("{Message}", message.Message);
                break;
            case LogSeverity.Debug:
                _logger.LogDebug("{Message}", message.Message);
                break;
        }

        return Task.CompletedTask;
    }

    private async Task ReadyAsync()
    {
        if (IsDebug())
        {
            // this is where you put the id of the test discord guild
            _logger.LogInformation("In debug mode, adding commands to {DevGuildID}...", _options.Permissions.DevGuildID);
            await _interactions.RegisterCommandsToGuildAsync(_options.Permissions.DevGuildID);
        }
        else
        {
            // this method will add commands globally, but can take around an hour
            await _interactions.RegisterCommandsGloballyAsync(true);
        }
        _logger.LogInformation("Connected as -> [{CurrentUser}] :)", _client.CurrentUser);
    }


    static bool IsDebug()
    {
#if DEBUG
        return true;
#else
            return false;
#endif
    }
}