using System;
using System.IO;
using System.Text;

namespace Azurlane
{
    internal static class Lua
    {
        internal static void Initialize(string lua, Tasks tasks)
        {
            try
            {
                Console.Write($"[+] {(tasks == Tasks.Decrypt ? "Decrypting" : tasks == Tasks.Encrypt ? "Encrypting" : tasks == Tasks.Decompile ? "Decompiling" : "Recompiling")} {Path.GetFileName(lua)}...");

                var luaPath = Path.Combine(PathMgr.Environment(tasks == Tasks.Decrypt ? "Decrypted_lua" : tasks == Tasks.Encrypt ? "Encrypted_lua" : tasks == Tasks.Decompile ? "Decompiled_lua" : "Recompiled_lua"), Path.GetFileName(lua));
                if (tasks == Tasks.Decrypt || tasks == Tasks.Encrypt)
                {
                    var bytes = File.ReadAllBytes(lua);
                    var reader = new BinaryReader(new MemoryStream(bytes));

                    var magic = reader.ReadBytes(3);
                    var version = reader.ReadByte();
                    var bits = reader.ReadUleb128();
                    var is_stripped = ((bits & 2u) != 0u);

                    if (!is_stripped)
                    {
                        var length = reader.ReadUleb128();
                        var name = Encoding.UTF8.GetString(reader.ReadBytes((int)length));
                    }

                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        var size = reader.ReadUleb128();

                        if (size == 0)
                            break;

                        var next = reader.BaseStream.Position + size;
                        bits = reader.ReadByte();

                        var arguments_count = reader.ReadByte();
                        var framesize = reader.ReadByte();
                        var upvalues_count = reader.ReadByte();
                        var complex_constants_count = reader.ReadUleb128();
                        var numeric_constants_count = reader.ReadUleb128();
                        var instructions_count = reader.ReadUleb128();

                        var start = (int)reader.BaseStream.Position;
                        start += 4;

                        var v2 = 0;
                        do
                        {
                            if (tasks == Tasks.Encrypt)
                            {
                                bytes[3] = 0x80;
                                var v3 = bytes[start - 4];
                                start += 4;
                                var v4 = bytes[start - 7] ^ v2++;
                                bytes[start - 8] = (byte)(Properties.Resources.Lock[v3] ^ v4);
                            }
                            else
                            {
                                bytes[3] = 2;
                                var v3 = bytes[start - 4];
                                start += 4;
                                var v4 = bytes[start - 7] ^ v3 ^ (v2++ & 0xFF);
                                bytes[start - 8] = Properties.Resources.Unlock[v4];
                            }
                        }
                        while (v2 != (int)instructions_count);
                        reader.BaseStream.Position = next;
                    }
                    
                    if (File.Exists(luaPath))
                        File.Delete(luaPath);

                    File.WriteAllBytes(luaPath, bytes);
                }
                else if (tasks == Tasks.Decompile || tasks == Tasks.Recompile)
                    Utils.Command(tasks == Tasks.Decompile ? $"python main.py -f \"{lua}\" -o \"{luaPath}\"" : $"luajit.exe -b \"{lua}\" \"{luaPath}\"");
                
                Console.Write("<done>");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static uint ReadUleb128(this BinaryReader reader)
        {
            uint value = reader.ReadByte();
            if (value >= 0x80)
            {
                var bitshift = 0;
                value &= 0x7f;
                while (true)
                {
                    var b = reader.ReadByte();
                    bitshift += 7;
                    value |= (uint)((b & 0x7f) << bitshift);
                    if (b < 0x80)
                        break;
                }
            }
            return value;
        }
    }
}