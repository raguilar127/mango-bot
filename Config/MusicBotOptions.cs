using Discord;
using Microsoft.Extensions.Options;

namespace Config
{
    public class MusicBotOptions
    {
        // The volume of the bot, between 0.01 and 1.0.
        public double DefaultVolume { get; set; } = 0.25;

        // The number of people voting to skip in order for a song to be skipped successfully,
        // whichever value is lower will be used. Ratio refers to the percentage of undefeaned, non-
        // owner users in the channel. 
        public int SkipsRequired { get; set; }
        public double SkipRatio { get; set; } = 0.5;

        // Determines if downloaded videos will be saved to the audio_cache folder. If this is yes,
        // they will not be redownloaded if found in the folder and queued again. Else, videos will
        // be downloaded to the folder temporarily to play, then deleted after to avoid filling space.
        public bool SaveVideos { get; set; }

        // Mentions the user who queued a song when it starts to play.
        public bool NowPlayingMentions { get; set; }

        // Automatically joins the owner's voice channel on startup, if possible. The bot must be on
        // the same server and have permission to join the channel.
        public bool AutoJoin { get; set; }

        // Start playing songs from the autoplaylist.txt file after joining a channel. This does not
        // stop users from queueing songs, you can do that by restricting command access in permissions.ini.
        public bool UseAutoPlaylist { get; set; }

        // Sets if the autoplaylist should play through songs in a random order when enabled. If no,
        // songs will be played in a sequential order instead.
        public bool AutoPlaylistRandom { get; set; }

        // Pause the music when nobody is in a voice channel, until someone joins again.
        public bool AutoPause { get; set; }

        // Automatically cleanup the bot's messages after a small period of time.
        public bool DeleteMessages { get; set; }

        // If this and DeleteMessages is enabled, the bot will also try to delete messages from other
        // users that called commands. The bot requires the 'Manage Messages' permission for this.
        public bool DeleteInvoking { get; set; }

        // Regularly saves the queue to the disk. If the bot is then shut down, the queue will
        // resume from where it left off.
        public bool PersistentQueue { get; set; }

        // Determines what messages are logged to the console. The default level is Information, which is
        // everything an average user would need. Other levels include 5 Critical, 4 Error , 3 Warning, 2 Information, 1 Debug, 0 Trace. You should only change this if you
        // are debugging, or you want the bot to have a quieter console output.
        public int DebugLevel { get; set; } = 2;

        // Specify a custom message to use as the bot's status. If left empty, the bot
        // will display dynamic info about music currently being played in its status instead.
        public string? StatusMessage { get; set; }

        // Write what the bot is currently playing to the data/<server id>/current.txt FILE.
        // This can then be used with OBS and anything else that takes a dynamic input.
        public bool WriteCurrentSong { get; set; }

        // Allows the person who queued a song to skip their OWN songs instantly, similar to the
        // functionality that owners have where they can skip every song instantly.
        public bool AllowAuthorSkip { get; set; }

        // Enables experimental equalization code. This will cause all songs to sound similar in
        // volume at the cost of higher processing consumption when the song is initially being played.
        public bool UseExperimentalEqualization { get; set; }

        // Enables the use of embeds throughout the bot. These are messages that are formatted to
        // look cleaner, however they don't appear to users who have link previews disabled in their
        // Discord settings.
        public bool UseEmbeds { get; set; }

        // The amount of items to show when using the queue command.
        public int QueueLength { get; set; } = 10;

        // Remove songs from the autoplaylist if an error occurred while trying to play them.
        // If enabled, unplayable songs will be moved to another file and out of the autoplaylist.
        // You may want to disable this if you have internet issues or frequent issues playing songs.
        public bool RemoveFromAPOnError { get; set; }

        // Whether to show the configuration for the bot in the console when it launches.
        public bool ShowConfigOnLaunch { get; set; }

        // Leave servers if the owner is not found in them.
        public bool LeaveServersWithoutOwner { get; set; }

        // Use command alias defined in aliases.json.
        public bool UseAlias { get; set; }

        // Use an altenate way to display the results from search command.
        public bool SearchList { get; set; }

        // Set the amount of search results returned by default
        public int DefaultSearchResults { get; set; } = 3;

        // Specify a custom message to use as the bots embed footer.
        public string? CustomEmbedFooter { get; set; }
    }

}