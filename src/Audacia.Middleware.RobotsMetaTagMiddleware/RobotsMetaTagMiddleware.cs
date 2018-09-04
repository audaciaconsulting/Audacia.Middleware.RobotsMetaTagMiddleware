using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Audacia.Extensions;
using Audacia.Middleware.Helpers;

namespace Audacia.Middleware
{
    /// <summary>
    /// A middleware for injecting OWASP recommended headers into a
    /// HTTP Request
    /// </summary>
    public class RobotsMetaTagMiddleware
    {
        private readonly RequestDelegate _next;

        public RobotsMetaTagMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// The main task of the middleware. This will be invoked whenever
        /// the middleware fires
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext" /> for the current request or response</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var xRobotsModel = XRobotsModelHelpers.CreateAudaciaDefault();

            httpContext.TryAddHeader("X-Robots-Tag", xRobotsModel.ToString());
            
            // Call the next middleware in the chain
            await _next.Invoke(httpContext);
        }
    }
}