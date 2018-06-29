using System;

namespace Azurlane.Configuration
{
    internal static class Enemy
    {
        internal static int AntiAir => string.Equals(ConfigMgr.Initialization["EnemyAntiAir"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyAntiAir"]);
        internal static int AntiAirGrowth => string.Equals(ConfigMgr.Initialization["EnemyAntiAirGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyAntiAirGrowth"]);
        internal static int Antisub => string.Equals(ConfigMgr.Initialization["EnemyAntisub"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyAntisub"]);
        internal static int AntisubGrowth => string.Equals(ConfigMgr.Initialization["EnemyAntisubGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyAntisubGrowth"]);
        internal static int Armor => string.Equals(ConfigMgr.Initialization["EnemyArmor"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyArmor"]);
        internal static int ArmorGrowth => string.Equals(ConfigMgr.Initialization["EnemyArmorGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyArmorGrowth"]);
        internal static int Cannon => string.Equals(ConfigMgr.Initialization["EnemyCannon"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyCannon"]);
        internal static int CannonGrowth => string.Equals(ConfigMgr.Initialization["EnemyCannonGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyCannonGrowth"]);
        internal static int Evasion => string.Equals(ConfigMgr.Initialization["EnemyEvasion"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyEvasion"]);
        internal static int EvasionGrowth => string.Equals(ConfigMgr.Initialization["EnemyEvasionGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyEvasionGrowth"]);
        internal static int Hit => string.Equals(ConfigMgr.Initialization["EnemyHit"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyHit"]);
        internal static int HitGrowth => string.Equals(ConfigMgr.Initialization["EnemyHitGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyHitGrowth"]);
        internal static int Hp => string.Equals(ConfigMgr.Initialization["EnemyHp"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyHp"]);
        internal static int HpGrowth => string.Equals(ConfigMgr.Initialization["EnemyHpGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyHpGrowth"]);
        internal static bool IsDisarmWeapon => string.Equals(ConfigMgr.Initialization["EnemyDisarmWeapon"], "true", StringComparison.OrdinalIgnoreCase);
        internal static bool IsRemoveSkill => string.Equals(ConfigMgr.Initialization["EnemyRemoveSkill"], "true", StringComparison.OrdinalIgnoreCase);
        internal static int Luck => string.Equals(ConfigMgr.Initialization["EnemyLuck"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyLuck"]);
        internal static int LuckGrowth => string.Equals(ConfigMgr.Initialization["EnemyLuckGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyLuckGrowth"]);
        internal static int Reload => string.Equals(ConfigMgr.Initialization["EnemyReload"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyReload"]);
        internal static int ReloadGrowth => string.Equals(ConfigMgr.Initialization["EnemyReloadGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyReloadGrowth"]);
        internal static int Speed => string.Equals(ConfigMgr.Initialization["EnemySpeed"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemySpeed"]);
        internal static int SpeedGrowth => string.Equals(ConfigMgr.Initialization["EnemySpeedGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemySpeedGrowth"]);
        internal static int Torpedo => string.Equals(ConfigMgr.Initialization["EnemyTorpedo"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyTorpedo"]);
        internal static int TorpedoGrowth => string.Equals(ConfigMgr.Initialization["EnemyTorpedoGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["EnemyTorpedoGrowth"]);
    }
}