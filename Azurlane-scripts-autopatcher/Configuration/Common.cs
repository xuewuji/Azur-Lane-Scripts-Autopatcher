using System;

namespace Azurlane.Configuration
{
    internal static class Common
    {
        internal static bool IsCreateGodMode => string.Equals(ConfigMgr.Initialization["CreateGodMode"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeCooldown => string.Equals(ConfigMgr.Initialization["CreateGodModeCooldown"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeDamage => string.Equals(ConfigMgr.Initialization["CreateGodModeDamage"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeDamageCooldown => string.Equals(ConfigMgr.Initialization["CreateGodModeDamageCooldown"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeDamageCooldownWeakEnemy => string.Equals(ConfigMgr.Initialization["CreateGodModeDamageCooldownWeakEnemy"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeDamageWeakEnemy => string.Equals(ConfigMgr.Initialization["CreateGodModeDamageWeakEnemy"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateGodModeWeakEnemy => string.Equals(ConfigMgr.Initialization["CreateGodModeWeakEnemy"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsCreateWeakEnemy => string.Equals(ConfigMgr.Initialization["CreateWeakEnemy"], "true", StringComparison.OrdinalIgnoreCase);
    }
}