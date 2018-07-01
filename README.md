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

## Requirements
1. Python 3.0 or newer
2. NET Framework 3.5 or newer

## Usage
Open `Azurlane.exe` and select *Azurlane AssetBundle file* named **scripts**, or by command `Azurlane.exe <path-to-scripts>`

You can obtain Azurlane AssetBundle file named scripts from:
- Japan: Android/data/com.YoStarJP.AzurLane/files/AssetBundles
- China (bilibili): Android/data/com.bilibili.azurlane/files/AssetBundles
- Korean: Android/data/com.txwy.and.blhx/files/AssetBundles

## Issues
### System Locale
The tool will not working properly if your System Locale is not set to English.

### Game stuck on loading
This issue will happens if you're playing China (bilibili) version of the game, simply remove these lines to fix this issue.

`Assembly-CSharp.dll > LuaScriptMgr > Load`
![DnSpy](https://a.safe.moe/OQevw5S.png)
