using System;
using Audacia.Middleware.RobotsMetaTagMiddleware.Models;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Helpers
{
    /// <summary>
    /// Builder to create a <see cref="XRobotsModel"/>. 
    /// </summary>
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
        ///     to not index any images it finds here ('noimageindex').
        /// </summary>
        /// <returns>An instance of the <see cref="XRobotsModel" /> with Dev Site defaults.</returns>
        public static XRobotsModelBuilder CreatePrivateAppDefault()
        {
            return CreateBuilder()
                    // Apply to all bots
                    .AddBotName(string.Empty)
                    .AddNone()
                    .AddNoArchive()
                    .AddNoSnippet()
                    .AddNoTranslate()
                    .AddNoImageIndex();
        }

        /// <summary>
        /// Creates an instance of the <see cref="XRobotsModel" />.
        /// </summary>
        /// <returns>A new instance of <see cref="XRobotsModel"/>.</returns>
        public static XRobotsModelBuilder CreateBuilder()
        {
            return new XRobotsModelBuilder();
        }

        /// <summary>
        /// The name of the bot to target. If blank, it applies to all bots.
        /// </summary>
        /// <param name="botname">The name of the bot.</param>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsModel.BotName"/> set to the provided <paramref name="botname"/>.</returns>
        public XRobotsModelBuilder AddBotName(string botname)
        {
            _config.BotName = botname;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoIndex` and `NoFollow` to true.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The name of this method initially doesn't make sense. 
        /// It is related to the 'none' value for the header, which:
        ///     > Equivalent to noindex, nofollow
        /// (from https://developers.google.com/search/reference/robots_meta_tag).
        /// </para>
        /// </remarks>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.All"/> to false and <see cref="XRobotsDirectivesModel.NoIndex"/> and <see cref="XRobotsDirectivesModel.NoFollow"/> to true.</returns>
        public XRobotsModelBuilder AddNone()
        {
            RemoveAll();
            _config.Directives.NoIndex = true;
            _config.Directives.NoFollow = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> NoIndex` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.All"/> to false and <see cref="XRobotsDirectivesModel.NoIndex"/> to true.</returns>
        public XRobotsModelBuilder AddNoIndex()
        {
            RemoveAll();
            _config.Directives.NoIndex = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoFollow` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.All"/> to false and `<see cref="XRobotsDirectivesModel.NoFollow"/> to true.</returns>
        public XRobotsModelBuilder AddNoFollow()
        {
            RemoveAll();
            _config.Directives.NoFollow = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoArchive` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.NoArchive"/> to true .</returns>
        public XRobotsModelBuilder AddNoArchive()
        {
            _config.Directives.NoArchive = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoSnippet` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.NoSnippet"/> to true .</returns>
        public XRobotsModelBuilder AddNoSnippet()
        {
            _config.Directives.NoSnippet = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoTranslate` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.NoTranslate"/> to true .</returns>
        public XRobotsModelBuilder AddNoTranslate()
        {
            _config.Directives.NoTranslate = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `NoImageIndex` to true.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.NoImageIndex"/> to true .</returns>
        public XRobotsModelBuilder AddNoImageIndex()
        {
            _config.Directives.NoImageIndex = true;
            
            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `UnavailableAfter` to true.
        /// </summary>
        /// <param name="value">The time after which the bot is no longer available.</param>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.UnavailableAfter"/> to <paramref name="value"/> .</returns>
        public XRobotsModelBuilder AddUnavailableAfter(DateTime value)
        {
            _config.Directives.UnavailableAfter = value;

            return this;
        }

        /// <summary>
        /// Set <see cref="XRobotsModel.Directives"/> `All` to false.
        /// </summary>
        /// <returns>This <see cref="XRobotsModelBuilder"/> with <see cref="XRobotsDirectivesModel.All"/> to false.</returns>
        public XRobotsModelBuilder RemoveAll()
        {
            _config.Directives.All = false;
            
            return this;
        }

        /// <summary>
        /// Get <see cref="XRobotsModelBuilder"/>'s config.
        /// </summary>
        /// <returns><see cref="XRobotsModelBuilder"/>'s modified <see cref="XRobotsModel"/>.</returns>
        public XRobotsModel Build()
        {
            return _config;
        }
    }
}
