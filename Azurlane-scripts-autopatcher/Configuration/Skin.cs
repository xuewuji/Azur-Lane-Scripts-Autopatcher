using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azurlane.Configuration
{
    internal class Skin
    {
        private static List<int> m_Id;

        internal static List<int> Id {
            get {
                if (m_Id == null)
                {
                    m_Id = new List<int>();
                    foreach (var Skins in ConfigMgr.Initialization["Skin"].Split(','))
                        m_Id.Add(int.Parse(Skins.Split(':')[1]));
                }
                return m_Id;
            }
        }
    }
}
