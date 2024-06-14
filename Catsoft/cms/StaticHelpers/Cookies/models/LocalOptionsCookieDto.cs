using System.Collections.Generic;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class LocalOptionsCookieDto()
    {
        public HashSet<Options.Options.Features> ToggleFeatures { get; set; } = new();
    }
}