using System.Reflection;
using System.Runtime.CompilerServices;
using Config;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly IServiceProvider _services;
        private readonly InteractionService _interactions;

        // Retrieve client and CommandService instance via ctor
        public CommandHandler(DiscordSocketClient client, InteractionService interactions, IServiceProvider services)
        {
            _interactions = interactions;
            _client = client;
            _services = services;

        }

        public async Task InitializeAsync() 
        {
            // add the public modules that inherit InteractionModuleBase<T> to the InteractionService
            await _interactions.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

            // handle incoming interactions
            _client.InteractionCreated += HandleInteraction;

            // handle results of execution
            _interactions.SlashCommandExecuted += SlashCommandExecuted;
            _interactions.ContextCommandExecuted += ContextCommandExecuted;
            _interactions.ComponentCommandExecuted += ComponentCommandExecuted;
        }

        private async Task HandleInteraction(SocketInteraction interaction)
        {
            try
            {
                // create an execution context that matches the generic type parameter of your InteractionModuleBase<T> modules
                var context = new SocketInteractionContext(_client, interaction);
                await _interactions.ExecuteCommandAsync(context, _services);
            }
            catch (Exception)
            {
                if (interaction.Type == InteractionType.ApplicationCommand)
                {
                    await interaction.GetOriginalResponseAsync().ContinueWith(
                        async (message) =>
                            await message.Result.DeleteAsync()
                    );
                }
            }
        }

        private Task SlashCommandExecuted(SlashCommandInfo data, IInteractionContext context, IResult result)
        {
            if (!result.IsSuccess)
            {
                switch (result.Error)
                {
                    case InteractionCommandError.UnknownCommand:
                        break;
                    case InteractionCommandError.ConvertFailed:
                        break;
                    case InteractionCommandError.BadArgs:
                        break;
                    case InteractionCommandError.Exception:
                        break;
                    case InteractionCommandError.Unsuccessful:
                        break;
                    case InteractionCommandError.UnmetPrecondition:
                        break;
                    case InteractionCommandError.ParseFailed:
                        break;
                }
            }

            return Task.CompletedTask;
        }

        private Task ContextCommandExecuted(ContextCommandInfo data, IInteractionContext context, IResult result)
        {
            if (!result.IsSuccess)
            {
                switch (result.Error)
                {
                    case InteractionCommandError.UnknownCommand:
                        break;
                    case InteractionCommandError.ConvertFailed:
                        break;
                    case InteractionCommandError.BadArgs:
                        break;
                    case InteractionCommandError.Exception:
                        break;
                    case InteractionCommandError.Unsuccessful:
                        break;
                    case InteractionCommandError.UnmetPrecondition:
                        break;
                    case InteractionCommandError.ParseFailed:
                        break;
                }
            }

            return Task.CompletedTask;
        }

        private Task ComponentCommandExecuted(ComponentCommandInfo data, IInteractionContext context, IResult result)
        {
            if (!result.IsSuccess)
            {
                switch (result.Error)
                {
                    case InteractionCommandError.UnknownCommand:
                        break;
                    case InteractionCommandError.ConvertFailed:
                        break;
                    case InteractionCommandError.BadArgs:
                        break;
                    case InteractionCommandError.Exception:
                        break;
                    case InteractionCommandError.Unsuccessful:
                        break;
                    case InteractionCommandError.UnmetPrecondition:
                        break;
                    case InteractionCommandError.ParseFailed:
                        break;
                }
            }

            return Task.CompletedTask;
        }

    }
}
