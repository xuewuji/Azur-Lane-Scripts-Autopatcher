using System;

namespace Azurlane.Configuration
{
    internal static class Weapon
    {
        internal static int Damage => string.Equals(ConfigMgr.Initialization["WeaponDamage"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["WeaponDamage"]);
        internal static int ReloadMax => string.Equals(ConfigMgr.Initialization["WeaponReloadMax"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["WeaponReloadMax"]);
    }
}