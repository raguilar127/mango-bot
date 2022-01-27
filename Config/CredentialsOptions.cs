namespace Config
{
    // To get IDs, enable Developer Mode (Options -> Settings -> Appearance)
    // on Discord and then right-click the person/channel you want to get the
    // channel of, then click 'Copy ID'. You can also use the 'listids' command.
    // (http://i.imgur.com/GhKpBMQ.gif)
    public class CredentialsOptions
    {
        // This is your Discord bot account token.
        // Find your bot's token here: https://discordapp.com/developers/applications/me/
        // Create a new application, with no redirect URI or boxes ticked.
        // Then click 'Create Bot User' on the application page and copy the token here.
        public string? Token { get; set; }

        // The bot supports converting Spotify links and URIs to YouTube videos and
        // playing them. The bot will try to generate it's own credentials and communicate with
        // Spotify's API using them. This will be automatically enabled when
        // the two options below are left empty.
        public string? Spotify_ClientID { get; set; }
        public string? Spotify_ClientSecret { get; set; }
    }

}