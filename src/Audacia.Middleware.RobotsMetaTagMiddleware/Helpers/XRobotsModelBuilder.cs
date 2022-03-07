using System;
using Audacia.Middleware.RobotsMetaTagMiddleware.Models;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Helpers
{
    public class XRobotsModelBuilder
    {
        private readonly XRobotsModel _config;

        private XRobotsModelBuilder()
        {
            _config = new XRobotsModel();
        }

        /// <summary>
        /// Creates an instance of the <see cref="XRobotsModel" /> which informs all
        /// web crawler bots:
        ///     to ignore this page, all of its links ('noindex' and 'nofollow')
        ///     to not cache the site ('noarchive')
        ///     to not show a text snippet or video ('nosnippet')
        ///     to not offer translation services ('notranslate')
        ///     to not index any images it finds here ('noimageindex')
        /// </summary>
        /// <returns>An instance of the <see cref="XRobotsModel" /> with Dev Site defaults</returns>
        public static XRobotsModelBuilder CreatePrivateAppDefault()
        {
            return CreateBuilder()
                    .AddBotName(string.Empty)   // Apply to all bots
                    .AddNone()
                    .AddNoArchive()
                    .AddNoSnippet()
                    .AddNoTranslate()
                    .AddNoImageIndex();
        }

        public static XRobotsModelBuilder CreateBuilder()
        {
            return new XRobotsModelBuilder();
        }

        public XRobotsModelBuilder AddBotName(string botname)
        {
            _config.BotName = botname;
            
            return this;
        }

        /// <summary>
        /// The name of this method initially doesn't make sense.
        /// It is related to the 'none' value for the header, which:
        ///     > Equivalent to noindex, nofollow
        /// (from https://developers.google.com/search/reference/robots_meta_tag)
        /// </summary>
        /// <param name="config"An instance of the <see cref="XRobotsModel" /></param>
        public XRobotsModelBuilder AddNone()
        {
            RemoveAll();
            _config.Directives.NoIndex = true;
            _config.Directives.NoFollow = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoIndex()
        {
            RemoveAll();
            _config.Directives.NoIndex = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoFollow()
        {
            RemoveAll();
            _config.Directives.NoFollow = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoArchive()
        {
            _config.Directives.NoArchive = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoSnippet()
        {
            _config.Directives.NoSnippet = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoTranslate()
        {
            _config.Directives.NoTranslate = true;
            
            return this;
        }

        public XRobotsModelBuilder AddNoImageIndex()
        {
            _config.Directives.NoImageIndex = true;
            
            return this;
        }

        public XRobotsModelBuilder AddUnavailableAfter(DateTime value)
        {
            _config.Directives.UnavailableAfter = value;

            return this;
        }

        public XRobotsModelBuilder RemoveAll()
        {
            _config.Directives.All = false;
            
            return this;
        }
        
        public XRobotsModel Build()
        {
            return _config;
        }
    }
}
