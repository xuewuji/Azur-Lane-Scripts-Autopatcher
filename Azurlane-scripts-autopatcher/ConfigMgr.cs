using Azurlane.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azurlane
{
    internal static class ConfigMgr
    {
        internal static List<string> ListOfLua, ListOfMod;
        private static Dictionary<string, string> m_Initialization;

        static ConfigMgr()
        {
            if (ListOfLua == null)
            {
                ListOfLua = new List<string>()
                {
                   "aircraft_template.lua.txt",
                    "enemy_data_statistics.lua.txt"
                };
            }

            if (ListOfMod == null)
                ListOfMod = new List<string>();
        }

        internal static Dictionary<string, string> Initialization {
            get {
                var initPath = PathMgr.Local("Azurlane.ini");
                if (!File.Exists(initPath))
                {
                    File.WriteAllText(initPath, Properties.Resources.Azurlane);
                }
                if (m_Initialization == null)
                {
                    m_Initialization = new Dictionary<string, string>();
                    foreach (var line in File.ReadAllLines(initPath))
                    {
                        if (line.Contains('='))
                            m_Initialization.Add(line.Split('=')[0], line.Split('=')[1]);
                    }
                }
                return m_Initialization;
            }
        }

        internal static void Initialize()
        {
            if (Common.IsCreateGodMode)
                ListOfMod.Add("godmode");

            if (Common.IsCreateGodModeCooldown)
                ListOfMod.Add("godmode-cd");

            if (Common.IsCreateGodModeDamage)
                ListOfMod.Add("godmode-dmg");

            if (Common.IsCreateGodModeDamageCooldown)
                ListOfMod.Add("godmode-dmg-cd");

            if (Common.IsCreateGodModeWeakEnemy)
                ListOfMod.Add("godmode-weakenemy");

            if (Common.IsCreateWeakEnemy)
                ListOfMod.Add("weakenemy");

            if (Common.IsCreateGodModeCooldown || Common.IsCreateGodModeDamage || Common.IsCreateGodModeDamageCooldown)
                ListOfLua.Add("weapon_property.lua.txt");

            if (Player.IsReplaceSkin)
                ListOfLua.Add("ship_data_statistics.lua.txt");

            if (Enemy.IsRemoveSkill)
                ListOfLua.Add("enemy_data_skill.lua.txt");
        }
    }
}