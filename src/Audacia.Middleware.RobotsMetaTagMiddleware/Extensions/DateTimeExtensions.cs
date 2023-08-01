using System;
using System.Globalization;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    /// <summary>
    /// Extension methods for the type <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a given nullable <see cref="DateTime" /> in RFC-850 format.
        /// </summary>
        /// <param name="dateTime">The DateTime to format.</param>
        /// <param name="timeZoneKey">
        /// The time zone key for the returned string - defaults to GMT.
        /// </param>
        /// <returns>
        /// A string representing the value of the supplied DateTime in RFC-850 format.
        /// An example would be:
        ///     Monday, 15-Aug-18 15:52:01 GTM
        /// for the given Date and Time:
        ///     Monday, 15th of August 2018 at 15:52:01.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="dateTime"/> is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "AV1704:Identifier contains one or more digits in its name", Justification = "Name defines the Datetime format.")]
        public static string ToRfc850Format(this DateTime? dateTime, string timeZoneKey = "GMT")
        {
            if (dateTime == null)
            {
                throw new ArgumentException("Supplied nullable DateTime does not have a value");
            }
            
            return dateTime.Value.ToRfc850Format(timeZoneKey);
        }

        /// <summary>
        /// Returns a given <see cref="DateTime" /> in RFC-850 format.
        /// </summary>
        /// <param name="dateTime">The DateTime to format.</param>
        /// <param name="timeZoneKey">
        /// The time zone key for the returned string - defaults to GMT.
        /// </param>
        /// <returns>
        /// A string representing the value of the supplied DateTime in RFC-850 format.
        /// An example would be:
        ///     Monday, 15-Aug-18 15:52:01 GTM
        /// for the given Date and Time:
        ///     Monday, 15th of August 2018 at 15:52:01.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "AV1704:Identifier contains one or more digits in its name", Justification = "Name defines the Datetime format.")]
        public static string ToRfc850Format(this DateTime dateTime, string timeZoneKey = "GMT")
        {
            return $"{dateTime.ToString($"dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture)} {timeZoneKey}";
        }
    }
}