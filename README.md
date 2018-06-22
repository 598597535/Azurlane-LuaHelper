# Azurlane-LuaHelper
A helper tool to encrypt and decrypt, decompile and recompile Azurlane's lua files

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

## System Locale
The tool will not working properly if your System Locale is not set to English.
