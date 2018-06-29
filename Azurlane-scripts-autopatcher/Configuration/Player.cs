using System;

namespace Azurlane.Configuration
{
    internal static class Player
    {
        internal static bool IsReplaceSkin => string.Equals(ConfigMgr.Initialization["PlayerReplaceSkin"], "true", StringComparison.OrdinalIgnoreCase);
    }
}