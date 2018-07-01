using Azurlane.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Azurlane
{
    internal static class RewriteMgr
    {
        internal static void Execute(string mod, string lua)
        {
            var listOfAction = new List<Action>()
            {
                {() => WriteToAircraft(mod, lua)},
                {() => WriteToEnemy(mod, lua)},
                {() => WriteToExtra(mod, lua)},
                {() => WriteToPlayer(lua)},
                {() => WriteToWeapon(mod, lua)},
            };

            foreach (var action in listOfAction)
                action.Invoke();
        }

        private static void Rewrite(string path, string pattern, string replacement) => File.WriteAllText(path, Regex.Replace(File.ReadAllText(path), pattern, replacement));

        private static void WriteToAircraft(string mod, string lua)
        {
            if (lua.Contains("aircraft_template") && mod.Contains("godmode"))
            {
                if (Aircraft.Accuracy != 1010011010)
                    Rewrite(lua, "accuracy = .*,", string.Format("accuracy = {0},", Aircraft.Accuracy.ToString()));

                if (Aircraft.AccuracyGrowth != 1010011010)
                    Rewrite(lua, "ACC_growth = .*,", string.Format("ACC_growth = {0},", Aircraft.AccuracyGrowth.ToString()));

                if (Aircraft.AttackPower != 1010011010)
                    Rewrite(lua, "attack_power = .*,", string.Format("attack_power = {0},", Aircraft.AttackPower.ToString()));

                if (Aircraft.AttackPowerGrowth != 1010011010)
                    Rewrite(lua, "AP_growth = .*,", string.Format("AP_growth = {0},", Aircraft.AttackPowerGrowth.ToString()));

                if (Aircraft.CrashDamage != 1010011010)
                    Rewrite(lua, "crash_DMG = .*,", string.Format("crash_DMG = {0},", Aircraft.CrashDamage.ToString()));

                if (Aircraft.Hp != 1010011010)
                    Rewrite(lua, "max_hp = .*,", string.Format("max_hp = {0},", Aircraft.Hp.ToString()));

                if (Aircraft.HpGrowth != 1010011010)
                    Rewrite(lua, "hp_growth = .*,", string.Format("hp_growth = {0},", Aircraft.HpGrowth.ToString()));

                if (Aircraft.Speed != 1010011010)
                    Rewrite(lua, "speed = .*,", string.Format("speed = {0},", Aircraft.Speed.ToString()));
            }
        }

        private static void WriteToEnemy(string mod, string lua)
        {
            if (lua.Contains("enemy_data_statistics"))
            {
                if (mod.Contains("godmode") && Enemy.IsDisarmWeapon)
                    Rewrite(lua, @"equipment_list = \{([^\}]+)\}", "equipment_list = {}");

                if (mod.Contains("weakenemy"))
                {
                    if (Enemy.Hp != 1010011010)
                        Rewrite(lua, "durability = .*,", string.Format("durability = {0},", Enemy.Hp.ToString()));

                    if (Enemy.HpGrowth != 1010011010)
                        Rewrite(lua, "durability_growth = .*,", string.Format("durability_growth = {0},", Enemy.HpGrowth.ToString()));
                }

                if (Enemy.AntiAir != 1010011010)
                    Rewrite(lua, "antiaircraft = .*,", string.Format("antiaircraft = {0},", Enemy.AntiAir.ToString()));

                if (Enemy.AntiAirGrowth != 1010011010)
                    Rewrite(lua, "antiaircraft_growth = .*,", string.Format("antiaircraft_growth = {0},", Enemy.AntiAirGrowth.ToString()));

                if (Enemy.Antisub != 1010011010)
                    Rewrite(lua, "antisub = .*,", string.Format("antisub = {0},", Enemy.Antisub.ToString()));

                if (Enemy.AntisubGrowth != 1010011010)
                    Rewrite(lua, "antisub_growth = .*,", string.Format("antisub_growth = {0},", Enemy.AntisubGrowth.ToString()));

                if (Enemy.Armor != 1010011010)
                    Rewrite(lua, "armor = .*,", string.Format("armor = {0},", Enemy.Armor.ToString()));

                if (Enemy.ArmorGrowth != 1010011010)
                    Rewrite(lua, "armor_growth = .*,", string.Format("armor_growth = {0},", Enemy.ArmorGrowth.ToString()));

                if (Enemy.Cannon != 1010011010)
                    Rewrite(lua, "cannon = .*,", string.Format("cannon = {0},", Enemy.Cannon.ToString()));

                if (Enemy.CannonGrowth != 1010011010)
                    Rewrite(lua, "cannon_growth = .*,", string.Format("cannon_growth = {0},", Enemy.CannonGrowth.ToString()));

                if (Enemy.Evasion != 1010011010)
                    Rewrite(lua, "dodge = .*,", string.Format("dodge = {0},", Enemy.Evasion.ToString()));

                if (Enemy.EvasionGrowth != 1010011010)
                    Rewrite(lua, "dodge_growth = .*,", string.Format("dodge_growth = {0},", Enemy.EvasionGrowth.ToString()));

                if (Enemy.Hit != 1010011010)
                    Rewrite(lua, "hit = .*,", string.Format("hit = {0},", Enemy.Hit.ToString()));

                if (Enemy.HitGrowth != 1010011010)
                    Rewrite(lua, "hit_growth = .*,", string.Format("hit_growth = {0},", Enemy.HitGrowth.ToString()));

                if (Enemy.Luck != 1010011010)
                    Rewrite(lua, "luck = .*,", string.Format("luck = {0},", Enemy.Luck.ToString()));

                if (Enemy.LuckGrowth != 1010011010)
                    Rewrite(lua, "luck_growth = .*,", string.Format("luck_growth = {0},", Enemy.LuckGrowth.ToString()));

                if (Enemy.Reload != 1010011010)
                    Rewrite(lua, "reload = .*,", string.Format("reload = {0},", Enemy.Reload.ToString()));

                if (Enemy.ReloadGrowth != 1010011010)
                    Rewrite(lua, "reload_growth = .*,", string.Format("reload_growth = {0},", Enemy.ReloadGrowth.ToString()));

                if (Enemy.Speed != 1010011010)
                    Rewrite(lua, "speed = .*,", string.Format("speed = {0},", Enemy.Speed.ToString()));

                if (Enemy.SpeedGrowth != 1010011010)
                    Rewrite(lua, "speed_growth = .*,", string.Format("speed_growth = {0},", Enemy.SpeedGrowth.ToString()));

                if (Enemy.Torpedo != 1010011010)
                    Rewrite(lua, "torpedo = .*,", string.Format("torpedo = {0},", Enemy.Torpedo.ToString()));

                if (Enemy.TorpedoGrowth != 1010011010)
                    Rewrite(lua, "torpedo_growth = .*,", string.Format("torpedo_growth = {0},", Enemy.TorpedoGrowth.ToString()));
            }
            else if (lua.Contains("enemy_data_skill") && Enemy.IsRemoveSkill)
            {
                Rewrite(lua, "is_repeat = 1", "is_repeat = 0");
                Rewrite(lua, @"skill_list = \{([^\}]+)\}", "skill_list = {}");
            }
        }

        private static void WriteToExtra(string mod, string lua)
        {
            if (lua.Contains("extraenemy_template") && mod.Contains("weakenemy") && Extra.Hp != 1010011010)
                Rewrite(lua, "hp = .*,", string.Format("hp = {0},", Enemy.TorpedoGrowth.ToString()));
        }

        private static void WriteToPlayer(string lua)
        {
            if (lua.Contains("ship_data_statistics") && Player.IsReplaceSkin)
            {
                foreach (var id in Skin.Id)
                {
                    var baseId = id - (id.ToString().EndsWith("1") ? 1 : id.ToString().EndsWith("2") ? 2 : id.ToString().EndsWith("3") ? 3 : id.ToString().EndsWith("4") ? 4 : 5);

                    Rewrite(lua, string.Format("skin_id = {0},", baseId), string.Format("skin_id = {0},", id));
                    Rewrite(lua, string.Format("skin_id = {0},", baseId + 1), string.Format("skin_id = {0},", id));
                    Rewrite(lua, string.Format("skin_id = {0},", baseId + 2), string.Format("skin_id = {0},", id));
                    Rewrite(lua, string.Format("skin_id = {0},", baseId + 3), string.Format("skin_id = {0},", id));
                    Rewrite(lua, string.Format("skin_id = {0},", baseId + 4), string.Format("skin_id = {0},", id));
                    Rewrite(lua, string.Format("skin_id = {0},", baseId + 5), string.Format("skin_id = {0},", id));
                }
            }
        }

        private static void WriteToWeapon(string mod, string lua)
        {
            if (lua.Contains("weapon_property"))
            {
                if (mod.Contains("dmg") && Weapon.Damage != 1010011010)
                    Rewrite(lua, "damage = .*,", string.Format("damage = {0},", Weapon.Damage.ToString()));

                if (mod.Contains("cd") && Weapon.ReloadMax != 1010011010)
                    Rewrite(lua, "reload_max = .*,", string.Format("reload_max = {0},", Weapon.ReloadMax.ToString()));
            }
        }
    }
}