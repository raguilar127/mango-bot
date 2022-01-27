namespace Config
{
    public class ChatOptions
    {
        // Determines the prefix that must be used before commands in the Discord chat.
        // e.g if you set this to *, the play command would be triggered using *play.
        public string CommandPrefix { get; set; } = "$";

        // Restricts the bot to only listening to certain text channels. To use this, add
        // the IDs of the text channels you would like the bot to listen to, seperated by
        // a space.
        public List<ulong> BindToChannels { get; set; } = new();

        // Changes the behavior of BindToChannels. Normally any messages sent to a channel not in
        // BindToChannels will be ignored. This option allows servers that do not have any bound
        // channels while other server have some defined to still use commands in any channel with
        // the Music Bot. Setting this to yes when there are no bound channels does nothing.
        public bool AllowUnboundServers { get; set; }

        // Allows the bot to automatically join servers on startup. To use this, add the IDs
        // of the voice channels you would like the bot to join on startup, seperated by a
        // space. Each server can have one channel. If this option and AutoSummon are
        // enabled, this option will take priority.
        public List<ulong> AutojoinChannels { get; set; } = new();

        // Send direct messages for now playing messages instead of sending them into the guild. They are
        // sent to the user who added the media being played. Now playing messages for automatic entries
        // are unaffected and follows NowPlayingChannels config. The bot will not delete direct messages.
        public bool DMNowPlaying { get; set; }

        // Disable now playing messages for entries automatically added by the bot, via the autoplaylist.
        public bool DisableNowPlayingAutomatic { get; set; }

        // For now playing messages that are unaffected by DMNowPlaying and DisableNowPlayingAutomatic,
        // determine which channels the bot is going to output now playing messages to. If this is not
        // specified for a server, now playing message for manually added entries will be sent in the same
        // channel that users used the command to add that entry, and now playing messages for automatically 
        // added entries will be sent to the same channel that the last now playing message was sent to if
        // this is not specified for a server if possible. Specifying more than one channel for a server
        // forces the bot to pick only one channel from the list to send messages to.
        public List<ulong> NowPlayingChannels { get; set; } = new();

        // The bot would try to delete (or edit) previously sent now playing messages by default. If you
        // don't want the bot to delete them (for keeping a log of what has been played), turn this 
        // option off.
        public bool DeleteNowPlaying { get; set; }
    }

}