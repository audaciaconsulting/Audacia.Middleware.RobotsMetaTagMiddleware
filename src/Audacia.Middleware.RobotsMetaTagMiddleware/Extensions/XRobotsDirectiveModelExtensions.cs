using System.Text;

using Audacia.Middleware.Models;

namespace Audacia.Middleware.Extensions
{
    public static class XRobotsDirectiveModelExtensions
    {
        public static string Render(this XRobotsDirectivesModel model)
        {
            // comma separated directive values
            // simple validation rules:
            //  1. Cannot have All and None
            //  2. None == Nofollow + NoIndex
            //      If all three true, return "none"

            if (model.All)
            {
                return "all";
            }

            var directiveBuilder = new StringBuilder();

            if (model.NoIndex)
            {
                directiveBuilder.Append("noindex");
            }

            return string.Empty;
        }
    }
}
