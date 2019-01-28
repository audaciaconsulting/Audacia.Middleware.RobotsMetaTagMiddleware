using Audacia.Middleware.Extensions;
using Audacia.Middleware.Models;

namespace Audacia.Middleware.Helpers
{
    public static class XRobotsModelHelpers
    {
        /// <summary>
        /// Creates an instance of the <see cref="XRobotsModel" /> which informs all
        /// web crawler bots that they have no limits on what they can do with the
        /// rendered page (i.e. it can crawl, index, archive, create snippets, offer
        /// translation, and index all images on the page).
        /// </summary>
        /// <returns>An instance of the <see cref="XRobotsModel" /> with Public Facing Live Site defaults</returns>
        public static XRobotsModel CreatePublicFacingLiveSiteDefault()
        {
            return XRobotsModelBuilder.CreateBuilder()
                    .RemoveAll()
                    .AddNoArchive()
                    .AddNoSnippet()
                    .AddBotName(string.Empty)   // Apply to all bots
                    .Build();
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
        public static XRobotsModel CreateDevSiteDefault()
        {
            return XRobotsModelBuilder.CreateBuilder()
                    .AddBotName(string.Empty)   // Apply to all bots
                    .AddNone()
                    .AddNoArchive()
                    .AddNoSnippet()
                    .AddNoTranslate()
                    .AddNoImageIndex()
                    .Build();
        }
    }
}
