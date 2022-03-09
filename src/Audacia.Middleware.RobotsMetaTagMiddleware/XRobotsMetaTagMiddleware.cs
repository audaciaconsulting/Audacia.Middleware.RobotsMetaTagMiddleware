using System.Threading.Tasks;
using Audacia.Middleware.RobotsMetaTagMiddleware.Extensions;
using Audacia.Middleware.RobotsMetaTagMiddleware.Models;
using Microsoft.AspNetCore.Http;

namespace Audacia.Middleware.RobotsMetaTagMiddleware
{
    /// <summary>
    /// A middleware for injecting OWASP recommended headers into a
    /// HTTP Request
    /// </summary>
    public class XRobotsMetaTagMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly XRobotsModel _config;

        public XRobotsMetaTagMiddleware(RequestDelegate next, XRobotsModel config)
        {
            _next = next;
            _config = config;
        }

        /// <summary>
        /// The main task of the middleware. This will be invoked whenever
        /// the middleware fires
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext" /> for the current request or response</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.TryAddHeader("X-Robots-Tag", _config.Render());
            
            // Call the next middleware in the chain
            await _next.Invoke(httpContext);
        }
    }
}