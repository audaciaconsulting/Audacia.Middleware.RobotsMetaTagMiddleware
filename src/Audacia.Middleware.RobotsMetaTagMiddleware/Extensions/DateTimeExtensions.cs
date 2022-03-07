using System;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a given nullable <see cref="DateTime" /> in RFC-850 format
        /// </summary>
        /// <param name="dateTime">The DateTime to format</param>
        /// <param name="timeZoneKey">
        /// The time zone key for the returned string - defaults to GMT
        /// </param>
        /// <returns>
        /// A string representing the value of the supplied DateTime in RFC-850 format.
        /// An example would be:
        ///     Monday, 15-Aug-18 15:52:01 GTM
        /// for the given Date and Time:
        ///     Monday, 15th of August 2018 at 15:52:01
        /// </returns>
        public static string ToRfc850Format(this DateTime? dateTime, string timeZoneKey = "GMT")
        {
            if (!dateTime.HasValue)
            {
                throw new ArgumentException("Supplied nullable DateTime does not have a value");
            }
            
            return dateTime.Value.ToRfc850Format(timeZoneKey);
        }

        /// <summary>
        /// Returns a given <see cref="DateTime" /> in RFC-850 format
        /// </summary>
        /// <param name="dateTime">The DateTime to format</param>
        /// <param name="timeZoneKey">
        /// The time zone key for the returned string - defaults to GMT
        /// </param>
        /// <returns>
        /// A string representing the value of the supplied DateTime in RFC-850 format.
        /// An example would be:
        ///     Monday, 15-Aug-18 15:52:01 GTM
        /// for the given Date and Time:
        ///     Monday, 15th of August 2018 at 15:52:01
        /// </returns>
        public static string ToRfc850Format(this DateTime dateTime, string timeZoneKey = "GMT")
        {
            return $"{dateTime.ToString($"dd MMM yyyy HH:mm:ss")} {timeZoneKey}";
        }
    }
}