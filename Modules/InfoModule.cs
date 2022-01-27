using Discord.Interactions;
using Services;

namespace Modules
{
    public class InfoModule : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService Commands { get; set; }
        private readonly CommandHandler _handler;

        // constructor injection is also a valid way to access the dependecies
        public InfoModule(CommandHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("echo", "Echoes the input")]
        public Task SayAsync(string echo)
            => RespondAsync(echo);
            
        // ReplyAsync is a method on ModuleBase 
    }
}