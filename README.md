# Azur-Lane-Scripts-Autopatcher
Automated tool that will help you to save your precious time when modifying Azur Lane scripts.

## System Requirements
1. NET Framework 4.5.1 or newer https://www.microsoft.com/en-us/download/details.aspx?id=40779
2. Python 3.7.0 with "Add Python 3.7 to PATH" option enabled https://www.python.org/ftp/python/3.7.0/python-3.7.0.exe
3. (Skip if "Add Python 3.7 to PATH" option is enabled) Added Python's directory into System Environment Variables named **Path** https://docs.python.org/3/using/windows.html#configuring-python)

## How to Use
Open `Azurlane.exe` and import *Azur Lane AssetBundle file* named **scripts**

You can obtain Azur Lane AssetBundle file named scripts from:
  - Japan: Android/data/com.YoStarJP.AzurLane/files/AssetBundles
  - China (bilibili): Android/data/com.bilibili.azurlane/files/AssetBundles
  - Korean: Android/data/com.txwy.and.blhx/files/AssetBundles

## Known Issues
### System Locale
AssetBundle extractor (UnityEx.exe) will not working properly when your System Locale is not English.

### Game Stuck onload
This issue will only happens if you're playing China (bilibili) version of the game, simply do the following step to fix this issue.

Use DnSpy to import game's dll file named Assembly-CSharp.dll, then search LuaScriptMgr and edit a method named Load(Action) and remove lines shown in the picture (see below).

WWWLoader.Inst.LoadFile(luaName, delegate(byte[] bytes)
{
        bytes = SaltAdapter.Make(System.IO.File.Exists(System.IO.Path.Combine(Application.persistentDataPath, "scripts")) System.IO.File.ReadAllBytes(System.IO.Path.Combine(Application.persistentDataPath, "scripts")) : bytes, false);
        this.StartCoroutine(this.LoadABFromBytes(bytes, delegate(AssetBundle ab)
        {
                luaBundle = ab;
                callback();
        }));
});
