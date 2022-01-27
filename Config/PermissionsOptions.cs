namespace Config
{
    public class PermissionsOptions
    {
        // This option determines which user has full permissions and control of the bot.
        // You can only set one owner, but you can use permissions.ini to give other
        // users access to more commands.
        // Setting this option to 'auto' will set the owner of the bot to the person who
        // created the bot application, which is usually what you want. Else, change it
        // to another user's ID.
        public ulong OwnerID { get; set; }

        public ulong DevGuildID { get; set; }

        // This option determines which users have access to developer-only commands.
        // Developer only commands are very dangerous and may break your bot if used
        // incorrectly, so it's highly recommended that you ignore this option unless you
        // are familiar with Python code.
        public List<ulong> DevIDs { get; set; } = new();

        // This option determines if the bot should respond to other any other bots
        // put bot ID's here seperated with spaces
        // Any id you put here the bot WILL respond to.
        public List<ulong> BotExceptionIDs { get; set; } = new();
    }

}