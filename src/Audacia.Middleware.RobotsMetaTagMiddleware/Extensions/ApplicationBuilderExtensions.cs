using Audacia.Middleware.RobotsMetaTagMiddleware.Models;
using Microsoft.AspNetCore.Builder;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseXRobotsMetaTagHeader(this IApplicationBuilder builder, XRobotsModel config)
        {
            return builder.UseMiddleware<XRobotsMetaTagMiddleware>(config);
        }
    }
}
