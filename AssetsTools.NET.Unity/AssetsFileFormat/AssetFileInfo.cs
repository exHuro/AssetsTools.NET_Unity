namespace AssetsTools.NET.Unity
{
    public class AssetFileInfo
    {
        public ulong index;
        public uint offs_curFile;
        public uint curFileSize;
        public uint curFileTypeOrIndex;
        public ushort inheritedUnityClass;
        public ushort scriptIndex;
        public byte unknown1;
        public static uint GetSize(uint version)
        {
            uint size = 0;
            size += 4;
            if (version >= 0x0E) size += 4;
            size += 12;
            if (version < 0x10) size += 2;
            if (version <= 0x10) size += 2;
            if (0x0F <= version && version <= 0x10) size += 4;
            return size;
        }
    }
}
