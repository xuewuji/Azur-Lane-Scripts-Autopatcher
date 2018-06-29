using System;

namespace Azurlane.Configuration
{
    internal static class Aircraft
    {
        internal static int Accuracy => string.Equals(ConfigMgr.Initialization["AircraftAccuracy"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftAccuracy"]);
        internal static int AccuracyGrowth => string.Equals(ConfigMgr.Initialization["AircraftAccuracyGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftAccuracyGrowth"]);
        internal static int AttackPower => string.Equals(ConfigMgr.Initialization["AircraftAttackPower"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftAttackPower"]);
        internal static int AttackPowerGrowth => string.Equals(ConfigMgr.Initialization["AircraftAttackPowerGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftAttackPowerGrowth"]);
        internal static int CrashDamage => string.Equals(ConfigMgr.Initialization["AircraftCrashDamage"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftCrashDamage"]);
        internal static int Hp => string.Equals(ConfigMgr.Initialization["AircraftHp"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftHp"]);
        internal static int HpGrowth => string.Equals(ConfigMgr.Initialization["AircraftHpGrowth"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftHpGrowth"]);
        internal static int Speed => string.Equals(ConfigMgr.Initialization["AircraftSpeed"], "ignore", StringComparison.OrdinalIgnoreCase) ? 1010011010 : int.Parse(ConfigMgr.Initialization["AircraftSpeed"]);
    }
}