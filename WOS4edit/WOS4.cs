using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

namespace WOS4edit
{
    public enum DataType : int
    {
        String = 4,
        Boolean = 0,
        Byte = -1, //unassigned
        Int32 = 1,
        Int64 = -2, //unassigned
        Single = 3
    }

    public struct Setting
    {
        public string Name;
        public object Data;
        public DataType Type;
    }

    public class Config
    {
        public Setting[] Settings;
        public int Version;
        public int Count;

        public Config()
        {
            Settings = new Setting[0];
            Count = Version = 0;
        }

        public int Find(string Name)
        {
            for(int i=0;i<Settings.Length;i++)
            {
                if (Settings[i].Name.ToLower() == Name.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public static class WOS4
    {
        public static Config Read(string Filename)
        {
            Config C = new Config();
            using (FileStream FS = File.OpenRead(Filename))
            {
                using (BinaryReader BR = new BinaryReader(FS))
                {
                    C.Version = BR.ReadInt32();
                    C.Count = BR.ReadInt32();
                    List<Setting> Settings = new List<Setting>();
                    while (FS.Position < FS.Length && Settings.Count < C.Count)
                    {
                        Setting S = new Setting();
                        S.Type = (DataType)BR.ReadInt32();
                        S.Name = ToString(BR.ReadBytes(BR.ReadInt32()));
                        switch (S.Type)
                        {
                            case DataType.Boolean:
                                S.Data = BR.ReadByte() == 1;
                                break;
                            case DataType.Byte:
                                S.Data = BR.ReadByte();
                                break;
                            case DataType.Int32:
                                S.Data = BR.ReadInt32();
                                break;
                            case DataType.Int64:
                                S.Data = BR.ReadInt64();
                                break;
                            case DataType.Single:
                                S.Data = BR.ReadSingle();
                                break;
                            case DataType.String:
                                S.Data = ToString(BR.ReadBytes(BR.ReadInt32()));
                                break;
                            default:
                                throw new Exception(string.Format("Unknown data type: {0} at offset 0x{1:X}", (int)S.Type, FS.Position - 8 - S.Name.Length));
                        }
                        Settings.Add(S);
                    }
                    C.Settings = Settings.ToArray();
                }
            }
            return C;
        }

        public static void Write(Config C, string FileName)
        {
            //write to memory stream first in case of error.
            using (MemoryStream MS = new MemoryStream())
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(C.Version);
                    BW.Write(C.Settings.Length);
                    foreach (Setting S in C.Settings)
                    {
                        BW.Write((int)S.Type);
                        BW.Write(S.Name.Length);
                        BW.Write(FromString(S.Name));
                        switch (S.Type)
                        {
                            case DataType.Boolean:
                                BW.Write((bool)S.Data);
                                break;
                            case DataType.Byte:
                                BW.Write((byte)S.Data);
                                break;
                            case DataType.Int32:
                                BW.Write((int)S.Data);
                                break;
                            case DataType.Int64:
                                BW.Write((long)S.Data);
                                break;
                            case DataType.Single:
                                BW.Write((float)S.Data);
                                break;
                            case DataType.String:
                                byte[] b = FromString((string)S.Data);
                                BW.Write(b.Length);
                                BW.Write(b);
                                break;
                            default:
                                throw new Exception(string.Format("Unknown data type: {0} in setting {1}", (int)S.Type, S.Name));
                        }
                    }
                    BW.Flush();
                    File.WriteAllBytes(FileName, MS.ToArray());
                }
            }
        }

        private static byte[] FromString(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        private static string ToString(byte[] b)
        {
            return Encoding.UTF8.GetString(b);
        }
    }
}
