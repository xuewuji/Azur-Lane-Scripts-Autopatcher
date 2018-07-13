using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azurlane.Configuration
{
    class Debug
    {
        internal static bool IsDebugMode => string.Equals(ConfigMgr.Initialization["DebugMode"], "true", StringComparison.OrdinalIgnoreCase);
    }
}
