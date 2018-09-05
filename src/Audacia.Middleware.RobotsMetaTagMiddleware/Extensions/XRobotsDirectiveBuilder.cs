
using Audacia.Middleware.Models;

namespace Audacia.Middleware.Extensions {

    public static class XRobotsModelExtensions
    {
        // needs a render method
        // returns a string of the format
        // "<BotName value> : <comma separated values (if true, add the name)>"
        // If (all) return "<botname>: all"
        // else process all of the others
        //  if (None) do not add "noindex, nofollow" <- check first
    }

    public static class XRobotsModelBuilder
    {
        private static XRobotsModel Config;

        public static XRobotsModel CreateBuilder()
        {
            Config = new XRobotsModel();
            return Config;
        }

        public static XRobotsModel AddBotName(this XRobotsModel config, string botname)
        {
            UpdatePrivateConfig(config);
            Config.BotName = botname;
            return Config;
        }

        /// <summary>
        /// The name of this method initially doesn't make sense.
        /// It is related to the 'none' value for the header, which:
        ///     > Equivalent to noindex, nofollow
        /// (from https://developers.google.com/search/reference/robots_meta_tag)
        /// </summary>
        /// <param name="config"An instance of the <see cref="XRobotsModel" /></param>
        public static XRobotsModel AddNone(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            RemoveAll();
            Config.Directives.NoIndex = true;
            Config.Directives.NoFollow = true;
            return Config;
        }

        public static XRobotsModel AddNoIndex(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            RemoveAll();
            Config.Directives.NoIndex = true;
            return Config;
        }

        public static XRobotsModel AddNoFollow(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            RemoveAll();
            Config.Directives.NoFollow = true;
            return Config;
        }

        public static XRobotsModel AddNoArchive(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            Config.Directives.NoArchive = true;
            return Config;
        }

        public static XRobotsModel AddNoSnippet(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            Config.Directives.NoSnippet = true;
            return Config;
        }

        public static XRobotsModel AddNoTranslate(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            Config.Directives.NoTranslate = true;
            return Config;
        }

        public static XRobotsModel AddNoImageIndex(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            Config.Directives.NoImageIndex = true;
            return config;
        }

        public static XRobotsModel Build(this XRobotsModel config)
        {
            UpdatePrivateConfig(config);
            return Config;
        }

        private static void UpdatePrivateConfig(XRobotsModel config)
        {
            Config = config;
        }

        private static void RemoveAll()
        {
            Config.Directives.All = false;
        }
    }
}
