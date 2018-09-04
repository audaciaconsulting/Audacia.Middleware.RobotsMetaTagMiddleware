using Microsoft.AspNetCore.Builder;

namespace Audacia.Middleware.Extensions
{
    public static class XRobotsMetTagMiddlewareExtensions
    {
        public static IApplicationBuilder UseXRobotsMetaTagMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RobotsMetaTagMiddleware>();
        }
    }
}
