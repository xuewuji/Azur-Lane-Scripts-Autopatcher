# Azurlane-scripts-autopatcher
Automated tool that will save your time to modify Azurlane scripts, resulting several modified scripts such as:
- godmode
- godmode-cd
- godmode-dmg
- godmode-dmg-cd
- godmode-weakenemy
- weakenemy

## Download
You can grab the binary from the [releases page](https://github.com/k0np4ku/Azurlane-scripts-autopatcher/releases).

[Azurlane-LuaHelper](https://github.com/k0np4ku/Azurlane-LuaHelper) exists if you want to do everything manually, or if you don't want to diry your hands and only curious with what's inside.

## Requirements
1. Python 3.0 or newer
2. NET Framework 3.5 or newer

## Usage and Examples
Open `Azurlane.exe` and select *Azurlane AssetBundle file* named **scripts**, or by command `Azurlane.exe <path-to-scripts>`

You can obtain Azurlane AssetBundle file named scripts from:
- Japan: Android/data/com.YoStarJP.AzurLane/files/AssetBundles
- China (bilibili): Android/data/com.bilibili.azurlane/files/AssetBundles
- Korean: Android/data/com.txwy.and.blhx/files/AssetBundles

### Examples
```
$ azurlane scripts-jp
[+] Copying AssetBundle to temp workspace...<done>
[+] Decrypting and Unpacking AssetBundle...<done>
[+] Decrypting and Decompiling Lua...1/3...2/3...3/3...<done>
[+] Cloning Lua and AssetBundle...1/6...2/6...3/6...4/6...5/6...6/6...<done>
[+] Rewriting Lua...1/6...2/6...3/6...4/6...5/6...6/6...<done>
[+] Recompiling and Encypting Lua...1/6...2/6...3/6...4/6...5/6...6/6...<done>
[+] Repacking and Encrypting AssetBundle...1/6...2/6...3/6...4/6...5/6...6/6...<done>
[+] Copying all modified AssetBundle to original location...1/6...2/6...3/6...4/6...5/6...6/6...<done>
[+] Cleaning...

Everything is ok, we're done.
Press any key to exit.
```

## Issues
### System Locale
The tool will not working properly if your System Locale is not set to English.

### Game stuck on loading
This issue will happens if you're playing China (bilibili) version of the game, simply remove these lines to fix this issue.

`Assembly-CSharp.dll > LuaScriptMgr > Load`
![DnSpy](https://raw.githubusercontent.com/k0np4ku/Azurlane-scripts-autopatcher/master/DnSpy.png)
