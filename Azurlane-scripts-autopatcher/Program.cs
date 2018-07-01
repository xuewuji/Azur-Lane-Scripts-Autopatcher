using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Azurlane
{
    internal enum Tasks
    {
        Encrypt,
        Decrypt,
        Decompile,
        Recompile,
        Unpack,
        Repack
    }

    internal static class Program
    {
        internal static int ExceptionCount;

        private static void Clean(string fileName)
        {
            if (File.Exists(PathMgr.Temporary(fileName))) File.Delete(PathMgr.Temporary(fileName));
            if (Directory.Exists(PathMgr.Lua(fileName).Replace("\\CAB-android", ""))) Utils.DeleteDirectory(PathMgr.Lua(fileName).Replace("\\CAB-android", ""));

            foreach (var mod in ConfigMgr.ListOfMod)
            {
                if (File.Exists(PathMgr.Temporary(mod))) File.Delete(PathMgr.Temporary(mod));
                if (Directory.Exists(PathMgr.Lua(mod).Replace("\\CAB-android", ""))) Utils.DeleteDirectory(PathMgr.Lua(mod).Replace("\\CAB-android", ""));
            }
        }

        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Open an AssetBundle...";
                    dialog.Filter = "Azurlane AssetBundle|scripts*";
                    dialog.CheckFileExists = true;
                    dialog.Multiselect = false;
                    dialog.ShowDialog();

                    if (File.Exists(dialog.FileName))
                    {
                        args = new[] { dialog.FileName };
                    }
                    else
                    {
                        Console.WriteLine("Please open an AssetBundle...");
                        goto END;
                    }
                }
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Invalid argument, usage: Azurlane.exe <path-to-assetbundle>");
                goto END;
            }

            var filePath = Path.GetFullPath(args[0]);
            var fileDirectoryPath = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileName(filePath);

            if (!File.Exists(filePath))
            {
                Console.WriteLine(Directory.Exists(fileDirectoryPath) ? string.Format("{0} is a directory, please input a file...", args[0]) : string.Format("{0} doesn't exists", args[0]));
                goto END;
            }

            if (!AssetBundleMgr.IsAssetBundleValid(filePath))
            {
                Console.WriteLine("Not a valid AssetBundle file...");
                goto END;
            }

            ConfigMgr.Initialize();

            for (var i = 0; i < ConfigMgr.ListOfMod.Count; i++)
                ConfigMgr.ListOfMod[i] = string.Format("{0}-{1}", fileName, ConfigMgr.ListOfMod[i]);

            Clean(fileName);

            var index = 1;

            var listOfAction = new List<Action>()
            {
                {
                    () =>
                    {
                        Console.Write("[+] Copying AssetBundle to temporary workspace...");
                        File.Copy(filePath, PathMgr.Temporary(fileName), true);
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Decrypting AssetBundle...");
                        AssetBundleMgr.Execute(PathMgr.Temporary(fileName), Tasks.Decrypt);
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Unpacking AssetBundle...");
                        AssetBundleMgr.Execute(PathMgr.Temporary(fileName), Tasks.Unpack);
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Decrypting Lua...");
                        foreach (var lua in ConfigMgr.ListOfLua)
                            LuaMgr.Execute(PathMgr.Lua(fileName, lua), Tasks.Decrypt);
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Decompiling Lua...");
                        foreach (var lua in ConfigMgr.ListOfLua)
                        {
                            Console.Write($" {index}/{ConfigMgr.ListOfLua.Count}");
                            LuaMgr.Execute(PathMgr.Lua(fileName, lua), Tasks.Decompile);
                            index++;
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Creating a copy of Lua & AssetBundle...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            if (!Directory.Exists(PathMgr.Lua(mod)))
                                Directory.CreateDirectory(PathMgr.Lua(mod));
                            foreach (var lua in ConfigMgr.ListOfLua)
                                File.Copy(PathMgr.Lua(fileName, lua), PathMgr.Lua(mod, lua), true);
                            File.Copy(PathMgr.Temporary(fileName), PathMgr.Temporary(mod), true);
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Rewriting Lua...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            foreach (var lua in ConfigMgr.ListOfLua)
                                RewriteMgr.Execute(mod, PathMgr.Lua(mod, lua));
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Recompiling Lua...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            foreach (var lua in ConfigMgr.ListOfLua)
                                LuaMgr.Execute(PathMgr.Lua(mod, lua), Tasks.Recompile);
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Encrypting Lua...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            foreach (var lua in ConfigMgr.ListOfLua)
                                LuaMgr.Execute(PathMgr.Lua(mod, lua), Tasks.Encrypt);
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Repacking AssetBundle...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            Console.Write($" {index}/{ConfigMgr.ListOfMod.Count}");
                            AssetBundleMgr.Execute(PathMgr.Temporary(mod), Tasks.Repack);
                            index++;
                        }
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Encrypting AssetBundle...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                            AssetBundleMgr.Execute(PathMgr.Temporary(mod), Tasks.Encrypt);
                    }
                },
                {
                    () =>
                    {
                        Console.Write("[+] Copying modified AssetBundle to original location...");
                        foreach (var mod in ConfigMgr.ListOfMod)
                        {
                            if (File.Exists(Path.Combine(fileDirectoryPath, mod)))
                                File.Delete(Path.Combine(fileDirectoryPath, mod));

                            File.Copy(PathMgr.Temporary(mod), Path.Combine(fileDirectoryPath, mod));
                        }
                    }
                }
            };

            try
            {
                foreach (var action in listOfAction)
                {
                    try
                    {
                        if (index != 1)
                            index = 1;

                        action.Invoke();
                    }
                    catch (Exception e)
                    {
                        Utils.Log("Exception detected", e);
                    }

                    Console.Write(" <Done>\n");
                }
            }
            finally
            {
                Console.Write("[!] Cleaning...");
                Clean(fileName);
                Console.Write(" <Done>\n");

                Console.WriteLine();
                Console.WriteLine(string.Format("[!] We're done, {0}", ExceptionCount != 0 ? "exception detected... please check Logs.txt" : "horray!"));
            }
            END:
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}