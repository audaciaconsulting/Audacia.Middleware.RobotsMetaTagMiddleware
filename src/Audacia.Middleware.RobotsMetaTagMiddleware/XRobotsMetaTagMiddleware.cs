using System.Threading.Tasks;
using Audacia.Middleware.RobotsMetaTagMiddleware.Extensions;
using Audacia.Middleware.RobotsMetaTagMiddleware.Models;
using Microsoft.AspNetCore.Http;

namespace Audacia.Middleware.RobotsMetaTagMiddleware
{
    /// <summary>
    /// A middleware for injecting OWASP recommended headers into a
    /// HTTP Request.
    /// </summary>
    public class XRobotsMetaTagMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly XRobotsModel _config;

        /// <summary>
        /// Creates an instance of the <see cref="XRobotsMetaTagMiddleware"/>.
        /// </summary>
        /// <param name="next">The request being processed.</param>
        /// <param name="config">Rules for managing robots.</param>
        public XRobotsMetaTagMiddleware(RequestDelegate next, XRobotsModel config)
        {
            _next = next;
            _config = config;
        }

        /// <summary>
        /// The main task of the middleware. This will be invoked whenever
        /// the middleware fires.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext" /> for the current request or response.</param>
        /// <returns>A task to add a header to a request.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1046:Asynchronous method name should end with 'Async'.", Justification = "Matches naming of `RequestDelegate`.")]
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.TryAddHeader("X-Robots-Tag", _config.Render());
            
            // Call the next middleware in the chain
            await _next.Invoke(httpContext).ConfigureAwait(false);
        }
    }
}