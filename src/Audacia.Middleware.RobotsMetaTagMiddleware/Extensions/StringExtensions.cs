namespace Audacia.Middleware.RobotsMetaTagMiddleware.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveLastInstanceOfChar(this string s, char toRemove)
        {
            var lastIndexOfChar = s.LastIndexOf(toRemove);
            if (lastIndexOfChar == s.Length)
            {
                return s.Remove(lastIndexOfChar);
            }

            return s;
        }
    }
}
