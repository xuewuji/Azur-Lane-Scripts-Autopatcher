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
                if (m_Initialization == null)
                {
                    var initPath = PathMgr.Local("Azurlane.ini");

                    if (File.Exists(initPath))
                        Update(initPath);

                    if (!File.Exists(initPath))
                        File.WriteAllText(initPath, Properties.Resources.Azurlane);

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
            if (Common.IsCreateGodMode && !Debug.IsDebugMode)
                ListOfMod.Add("godmode");

            if (Common.IsCreateGodModeCooldown && !Debug.IsDebugMode)
                ListOfMod.Add("godmode-cd");

            if (Common.IsCreateGodModeDamage && !Debug.IsDebugMode)
                ListOfMod.Add("godmode-dmg");

            if (Common.IsCreateGodModeDamageCooldown && !Debug.IsDebugMode)
                ListOfMod.Add("godmode-dmg-cd");

            if (Common.IsCreateGodModeWeakEnemy && !Debug.IsDebugMode)
                ListOfMod.Add("godmode-weakenemy");

            if (Common.IsCreateGodModeDamageWeakEnemy && !Debug.IsDebugMode)
                ListOfMod.Add("godmode-dmg-weakenemy");

            if (Common.IsCreateGodModeDamageCooldownWeakEnemy)
                ListOfMod.Add("godmode-dmg-cd-weakenemy");

            if (Common.IsCreateWeakEnemy && !Debug.IsDebugMode)
                ListOfMod.Add("weakenemy");

            if (Common.IsCreateGodModeCooldown || Common.IsCreateGodModeDamage || Common.IsCreateGodModeDamageCooldown)
                ListOfLua.Add("weapon_property.lua.txt");

            if (Enemy.IsRemoveSkill)
                ListOfLua.Add("enemy_data_skill.lua.txt");
        }

        private static void Update(string path)
        {
            if (!File.ReadAllText(path).Contains("v2.7.1"))
            {
                File.Copy(path, string.Concat(Path.GetFileNameWithoutExtension(path), ".old", Path.GetExtension(path)), true);
                File.Delete(path);
            }
        }
    }
}