using System;
using System.Text;
using Audacia.Middleware.RobotsMetaTagMiddleware.Extensions;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Models
{
    /// <summary>
    /// Robot tag meta data class.
    /// </summary>
    public class XRobotsDirectivesModel
    {
        /// <summary>
        /// Creates an instance of the <see cref="XRobotsDirectivesModel" />.
        /// </summary>
        public XRobotsDirectivesModel()
        {
            All = true;
            UnavailableAfter = default;
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are no restrictions for indexing or serving. Note: this directive
        /// is the default value and has no effect if explicitly listed.
        /// </summary>
        /// <value>Default (via parameterless constructor) is true.</value>
        public bool All { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not show this page in search results and do not show a "Cached" link
        /// in search results.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not follow the links on this page.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoFollow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not show a "Cached" link in search results.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoArchive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not show a text snippet or video preview in the search results for this
        /// page. A static thumbnail (if available) will still be visible.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoSnippet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not offer translation of this page in search results.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoTranslate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether do not index images on this page.
        /// </summary>
        /// <value>Default (via parameterless constructor) is false.</value>
        public bool NoImageIndex { get; set; }

        /// <summary>
        /// Gets or sets do not show this page in search results after the specified date/time. The
        /// date/time will be rendered in the RFC 850 format.
        /// </summary>
        /// <value>Default (via parameterless constructor) is null.</value>
        public DateTime? UnavailableAfter { get; set; }

        /// <summary>
        /// Build the <see cref="XRobotsDirectivesModel"/>.
        /// </summary>
        /// <returns>Get the robots meta tag as a <see cref="string"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "ACL1002:Member or local function contains too many statements", Justification = "Easier to read and understand in one method.")]
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
            else if (NoIndex)
            {
                builder.Append("noindex, ");
            }
            else if (NoFollow)
            {
                builder.Append("nofollow, ");
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

            if (UnavailableAfter != null)
            {
                builder.Append("unavailable_after: ").Append(UnavailableAfter.ToRfc850Format("GMT")).Append(", ");
            }

            // Remove the last two characters as the builder will always end with ", "
            return builder.Remove(builder.Length - 2, 2).ToString();
        }
    }
}
