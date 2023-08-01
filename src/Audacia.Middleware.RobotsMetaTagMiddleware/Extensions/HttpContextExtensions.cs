using System;
using Microsoft.AspNetCore.Http;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    /// <summary>
    /// Extension methods for the type <see cref="HttpContext"/>.
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Check if response contains a specified header.
        /// </summary>
        /// <param name="httpContext">The context of the reponse.</param>
        /// <param name="header">The name of the header to search for.</param>
        /// <returns>If the response contains the named header.</returns>
        public static bool ResponseContainsHeader(this HttpContext httpContext, string header)
        {
            return httpContext?.Response.Headers.ContainsKey(header) ?? false;
        }

        /// <summary>
        /// Attempts to add a header to a http context and return if it succeeds.
        /// </summary>
        /// <param name="httpContext">The http context to modify.</param>
        /// <param name="headerName">The name of the header.</param>
        /// <param name="headerValue">The value of the header.</param>
        /// <returns>If the header was added successfully.</returns>
        public static bool TryAddHeader(this HttpContext httpContext, string headerName, string headerValue)
        {
            if (httpContext.ResponseContainsHeader(headerName))
            {
                httpContext.TryRemoveHeader(headerName);
            }

            try
            {
                httpContext.Response.Headers.Add(headerName, headerValue);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Used to remove a header (supplied via <paramref name="headerName"/>) from the current
        /// <paramref name="httpContext"/>.
        /// </summary>
        /// <param name="httpContext">The current <see cref="HttpContext"/>.</param>
        /// <param name="headerName">The name of the HTTP header to remove.</param>
        /// <returns>If the header was added removed.</returns>
        public static bool TryRemoveHeader(this HttpContext httpContext, string headerName)
        {
            if (!httpContext.ResponseContainsHeader(headerName))
            {
                return true;
            }

            try
            {
                httpContext.Response.Headers.Remove(headerName);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}