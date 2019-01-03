using Audacia.Middleware.Models;
using Microsoft.AspNetCore.Builder;

namespace Audacia.Middleware.Extensions
{
    public static class XRobotsMetTagMiddlewareExtensions
    {
        public static IApplicationBuilder UseXRobotsMetaTagMiddleware(this IApplicationBuilder builder, XRobotsModel config)
        {
            return builder.UseMiddleware<RobotsMetaTagMiddleware>(config);
        }
    }
}
