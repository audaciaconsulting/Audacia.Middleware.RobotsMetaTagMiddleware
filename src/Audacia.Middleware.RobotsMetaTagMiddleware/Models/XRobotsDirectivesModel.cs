using System;
using System.Text;
using Audacia.Middleware.RobotsMetaTagMiddleware.Extensions;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Models
{
    public class XRobotsDirectivesModel
    {
        public XRobotsDirectivesModel()
        {
            All = true;
            UnavailableAfter = default;
        }

        /// <summary>
        /// There are no restrictions for indexing or serving. Note: this directive
        /// is the default value and has no effect if explicitly listed.
        /// </summary>
        /// <value>Default (via parameterless constructor) is true</value>
        public bool All { get; set; }

        /// <summary>
        /// Do not show this page in search results and do not show a "Cached" link
        /// in search results.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoIndex { get; set; }

        /// <summary>
        /// Do not follow the links on this page
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoFollow { get; set; }

        /// <summary>
        /// Do not show a "Cached" link in search results.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoArchive { get; set; }

        /// <summary>
        /// Do not show a text snippet or video preview in the search results for this
        /// page. A static thumbnail (if available) will still be visible.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoSnippet { get; set; }

        /// <summary>
        /// Do not offer translation of this page in search results
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoTranslate { get; set; }

        /// <summary>
        /// Do not index images on this page
        /// </summary>
        /// <value>Default (via parameterless constructor) is false</value>
        public bool NoImageIndex { get; set; }

        /// <summary>
        /// Do not show this page in search results after the specified date/time. The
        /// date/time will be rendered in the RFC 850 format.
        /// </summary>
        /// <value>Default (via parameterless constructor) is null</value>
        public DateTime? UnavailableAfter { get; set; }

        public string Render()
        {
            if (All)
            {
                return "all";
            }
            var builder = new StringBuilder();

            // If both NoIndex and NoFollow are set, we can use "none"
            // rather than include both
            if (NoIndex && NoFollow)
            {
                builder.Append("none, ");
            }
            else
            {
                if (NoIndex)
                {
                    builder.Append("noindex, ");
                }
                else if (NoFollow)
                {
                    builder.Append("nofollow, ");
                }
            }

            if (NoArchive)
            {
                builder.Append("noarchive, ");
            }

            if (NoSnippet)
            {
                builder.Append("nosnippet, ");
            }

            if (NoTranslate)
            {
                builder.Append("notranslate, ");
            }

            if (NoImageIndex)
            {
                builder.Append("noimageindex, ");
            }

            if (UnavailableAfter.HasValue)
            {
                builder.Append($"unavailable_after: {UnavailableAfter.ToRfc850Format("GMT")}, ");
            }

            // Remove the last two characters as the builder will always end with ", "
            return builder.Remove(builder.Length - 2, 2).ToString();
        }
    }
}
