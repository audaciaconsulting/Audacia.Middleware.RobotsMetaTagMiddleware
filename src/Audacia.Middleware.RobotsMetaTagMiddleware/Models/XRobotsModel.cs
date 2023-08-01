namespace Audacia.Middleware.RobotsMetaTagMiddleware.Models
{
    /// <summary>
    /// A class for defining rules for bot(s).
    /// </summary>
    public class XRobotsModel
    {
        /// <summary>
        /// Creates an instance of the <see cref="XRobotsDirectivesModel"/>.
        /// </summary>
        public XRobotsModel()
        {
            BotName = string.Empty;
            Directives = new XRobotsDirectivesModel();
        }

        /// <summary>
        /// Gets or sets the name of the bot this rule relates to. For example:
        ///     googlebot: noindex, nofollow
        /// says that the google bot should not index this page, and that it
        /// should not follow any links it finds on this page.
        /// Whereas the following:
        ///     googlebot-news: nosnippet
        /// says that the Google news bot should not show either a text
        /// snippet or video preview in the search results for this page
        /// A blank or null value applies to all bots.
        /// </summary>
        /// <value>(Default) <see cref="string.Empty" />.</value>
        public string BotName { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the directives to apply for the specified <see cref="BotName"/>.
        /// </summary>
        /// <value>(Default) Allow all.</value>
        public XRobotsDirectivesModel Directives { get; set; }

        /// <summary>
        /// Build the <see cref="XRobotsModel"/>.
        /// </summary>
        /// <returns>Get the robots meta tag as a <see cref="string"/>.</returns>
        public string Render()
        {
            return string.IsNullOrWhiteSpace(BotName)
                ? $"{Directives.Render()}"
                : $"{BotName}: {Directives.Render()}";
        }
    }
}
