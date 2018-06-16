# Azurlane-LuaHelper
A helper tool to encrypt and decrypt, decompile and recompile Azurlane's lua files.

## Download
You can grab the binary from the [releases page](https://github.com/k0np4ku/Azurlane-LuaHelper/releases).

## Requirements
1. Python 3.0 or newer
2. NET Framework 3.5 or newer

## Usage and examples
```
Usage: Azurlane.exe <option> <path-to-file(s) or path-to-directory(s)>
>!You can input multiple files or directory, and lua & assetbundle are the only acceptable file!<

Options:
  -u, --unlock               Decrypt Lua
  -l, --lock                 Encrypt Lua
  -d, --decompile            Decompile Lua
  -r, --recompile            Recompile Lua
      --decrypt              Decrypt AssetBundle
      --encrypt              Encrypt AssetBundle
      --unpack               Unpack all lua from AssetBundle
      --repack               Repack all lua from AssetBundle
```

### Examples
```
$ azurlane --decrypt scripts
[+] Decrypting scripts...<done>
$ azurlane --unpack scripts
[+] Unpacking scripts...<done>
>!Unpacking assetbundle is done, output: C:\Users\Konpaku\Desktop\Azurlane-LuaHelper\Unity_Assets_Files
$ azurlane --unlock Unity_Assets_Files
[+] Decrypting 0000000.lua.txt...<done>
[+] Decrypting 0000001.lua.txt...<done>
>!Decrypt is done, output: C:\Users\Konpaku\Desktop\Azurlane-LuaHelper\Decrypted_lua
$ azurlane --decompile Decrypted_lua
[+] Decompiling 0000000.lua.txt...<done>
[+] Decompiling 0000001.lua.txt...<done>
>!Decompile is done, output: C:\Users\Konpaku\Desktop\Azurlane-LuaHelper\Decompiled_lua

--Manual labor: Modifying some decompiled lua, and thereafter recompile it--

$ azurlane --recompile Decompiled_lua
[+] Recompiling 0000000.lua.txt...<done>
[+] Recompiling 0000001.lua.txt...<done>
>!Recompile is done, output: C:\Users\Konpaku\Desktop\Azurlane-LuaHelper\Recompiled_lua

--Manual labor: Copying all modified lua inside Recompiled_lua folder to Unity_Assets_Files\scripts\CAB-android folder, and thereafter repack it--

$ azurlane --repack scripts
[+] Repacking scripts...<done>
$ azurlane --encrypt scripts
[+] Encrypting scripts...<done>
```
## Steps for dummies
1. Get a copy of scripts from Android/data/xxx/files/AssetBundles and move the said file to the same location as `Azurlane.exe`
   - xxx:
      - Japan: com.YoStarJP.AzurLane
      - China (bilibili): com.bilibili.azurlane
      - Korean: com.txwy.and.blhx
2. The scripts is encrypted, let's decrypt it by opening command-line and type `Azurlane.exe --decrypt scripts`
3. Next step, let's unpack all lua by typing `Azurlane.exe --unpack scripts`
   - The unpacked lua will be inside `Unity_Assets_Files\scripts-jp\CAB-android` folder
4. All lua is encrypted, let's decrypt all of them and type `Azurlane.exe --unlock Unity_Assets_Files`
   - The decrypted lua will be inside `Decrypted_lua`
5. Next step, let's decompile every lua and type `Azurlane.exe --decompile Decrypted_lua`
   - If you don't want to decompile every lua, you can delete and left the one that you want to decompile
   - The decompiled lua will be inside `Decompiled_lua`
6. Next step, let's edit some lua, now it's all on your own.
7. After you're done editing, let's recompile them and type `Azurlane.exe --recompile Decompiled_lua`
   - The recompiled lua will be inside `Recompiled_lua`
8. Next step, let's copy all lua inside `Recompiled_lua` folder back to `Unity_Assets_Files\scripts-jp\CAB-android` folder
9. Next step, let's repack the scripts and type `Azurlane.exe --repack scripts`
   - Scripts will be repacked and overwrite the existing, make a backup beforehand if you don't want to lose the original file
10. Next, scripts is repacked but left decrypted, let's encrypt it and type `Azurlane.exe --encrypt scripts`
11. Done.
12. ???
13. Profit
