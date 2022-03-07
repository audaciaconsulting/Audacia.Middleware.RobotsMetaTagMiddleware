namespace Audacia.Middleware.RobotsMetaTagMiddleware.Models
{
    public class XRobotsModel
    {
        public XRobotsModel()
        {
            BotName = string.Empty;
            Directives = new XRobotsDirectivesModel();
        }

        /// <summary>
        /// The name of the bot this rule relates to. For example:
        ///     googlebot: noindex, nofollow
        /// says that the google bot should not index this page, and that it
        /// should not follow any links it finds on this page.
        /// Whereas the following:
        ///     googlebot-news: nosnippet
        /// says that the Google news bot should not show either a text
        /// snippet or video preview in the search results for this page
        /// A blank or null value applies to all bots
        /// </summary>
        /// <value>(Default) <see cref="String.Empty" /></value>
        public string BotName { get; set; } = string.Empty;
        
        /// <summary>
        /// The directives to apply for the specified <see cref="BotName"/>
        /// </summary>
        /// <value>(Default) Allow all</value>
        public XRobotsDirectivesModel Directives { get; set; }

        public string Render()
        {
            return string.IsNullOrWhiteSpace(BotName)
                ? $"{Directives.Render()}"
                : $"{BotName}: {Directives.Render()}";
        }
    }
}
