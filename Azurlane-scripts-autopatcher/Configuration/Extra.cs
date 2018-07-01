using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azurlane.Configuration
{
    class Extra
    {
        internal static int Hp => string.Equals(ConfigMgr.Initialization["ExtraEnemyHp"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["ExtraEnemyHp"]);
    }
}
