
using Audacia.Middleware.Models;

namespace Audacia.Middleware.Extensions
{
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
            RemoveAll(config);
            Config.Directives.NoIndex = true;
            Config.Directives.NoFollow = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoIndex(this XRobotsModel config)
        {
            RemoveAll(config);
            Config.Directives.NoIndex = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoFollow(this XRobotsModel config)
        {
            RemoveAll(config);
            Config.Directives.NoFollow = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoArchive(this XRobotsModel config)
        {
            Config.Directives.NoArchive = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoSnippet(this XRobotsModel config)
        {
            Config.Directives.NoSnippet = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoTranslate(this XRobotsModel config)
        {
            Config.Directives.NoTranslate = true;
            UpdatePrivateConfig(config);
            return Config;
        }

        public static XRobotsModel AddNoImageIndex(this XRobotsModel config)
        {
            Config.Directives.NoImageIndex = true;
            UpdatePrivateConfig(config);
            return config;
        }

        public static XRobotsModel RemoveAll(this XRobotsModel config)
        {
            config.Directives.All = false;
            UpdatePrivateConfig(config);
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

    }
}
