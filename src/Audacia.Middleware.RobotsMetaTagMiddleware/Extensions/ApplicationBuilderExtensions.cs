using Audacia.Middleware.RobotsMetaTagMiddleware.Models;
using Microsoft.AspNetCore.Builder;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    /// <summary>
    /// Extension methods for the type <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds middleware to include robot meta tag headers in requests.
        /// </summary>
        /// <param name="builder">The project's application builder.</param>
        /// <param name="config">The robot configuration.</param>
        /// <returns>The provided <paramref name="builder"/> with <see cref="XRobotsMetaTagMiddleware"/> added.</returns>
        public static IApplicationBuilder UseXRobotsMetaTagHeader(this IApplicationBuilder builder, XRobotsModel config)
        {
            return builder.UseMiddleware<XRobotsMetaTagMiddleware>(config);
        }
    }
}
