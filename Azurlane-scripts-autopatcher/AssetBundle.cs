using System;
using System.IO;
using System.Reflection;

namespace Azurlane
{
    internal static class AssetBundle
    {
        private static readonly object Instance;

        static AssetBundle()
        {
            if (Instance == null)
                Instance = Activator.CreateInstance(Assembly.Load(Properties.Resources.Salt).GetType("LL.Salt"));
        }

        internal static void Run(string path, Tasks task)
        {
            if (task == Tasks.Decrypt || task == Tasks.Encrypt)
            {
                var bytes = File.ReadAllBytes(path);
                var method = Instance.GetType().GetMethod("Make", BindingFlags.Static | BindingFlags.Public);
                bytes = (byte[])method.Invoke(Instance, new object[] { bytes, task == Tasks.Encrypt });

                File.WriteAllBytes(path, bytes);
            }
            else if (task == Tasks.Unpack || task == Tasks.Repack)
            {
                Utils.Command(string.Format("UnityEX.exe {0} \"{1}\"", task == Tasks.Unpack ? "export" : "import", path));
            }
        }
    }
}