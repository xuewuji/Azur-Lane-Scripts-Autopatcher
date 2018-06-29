using System.IO;
using System.Reflection;

namespace Azurlane
{
    internal static class PathMgr
    {
        static PathMgr()
        {
            if (!Directory.Exists(Thirdparty()))
            {
                Directory.CreateDirectory(Thirdparty());
            }

            if (!Directory.Exists(Temporary()))
            {
                Directory.CreateDirectory(Temporary());
            }
        }

        internal static string Local(string path = null) => path != null ? Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), path) : Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        internal static string Lua(string name) => Path.Combine(Temporary("Unity_Assets_Files"), string.Format("{0}\\CAB-android", name));

        internal static string Lua(string name, string lua) => Path.Combine(Lua(name), lua);

        internal static string Temporary(string path = null) => path != null ? Path.Combine(Local("Temporary"), path) : Local("Temporary");

        internal static string Thirdparty(string path = null) => path != null ? Path.Combine(Local("Thirdparty"), path) : Local("Thirdparty");
    }
}