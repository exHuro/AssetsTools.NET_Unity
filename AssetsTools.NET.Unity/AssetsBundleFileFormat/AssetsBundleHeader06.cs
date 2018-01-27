namespace AssetsTools.NET.Unity
{
    public struct AssetsBundleHeader06
    {
        public string signature;
        public uint fileVersion;
        public string minPlayerVersion;
        public string fileEngineVersion;
        public ulong totalFileSize;
        public uint compressedSize;
        public uint decompressedSize;
        public uint flags;
        
        public bool Read(AssetsFileReader reader/*, AssetsFileVerifyLogger errorLogger = null*/)
        {
            signature = reader.ReadNullTerminated();
            fileVersion = reader.ReadUInt32();
            minPlayerVersion = reader.ReadNullTerminated();
            fileEngineVersion = reader.ReadNullTerminated();
            totalFileSize = reader.ReadUInt64();
            compressedSize = reader.ReadUInt32();
            decompressedSize = reader.ReadUInt32();
            flags = reader.ReadUInt32();
            return true;
        }
        public bool Write(AssetsFileWriter writer, ulong curFilePos/*, AssetsFileVerifyLogger errorLogger = NULL*/)
        {
            writer.Position = curFilePos;
            writer.WriteNullTerminated(signature);
            writer.Write(fileVersion);
            writer.WriteNullTerminated(minPlayerVersion);
            writer.WriteNullTerminated(fileEngineVersion);
            writer.Write(totalFileSize);
            writer.Write(compressedSize);
            writer.Write(decompressedSize);
            writer.Write(flags);
            return true;
        }
        public ulong GetBundleInfoOffset()
        {
            if ((flags & 0x80) != 0)
            {
                if (totalFileSize == 0)
                    return unchecked((ulong)-1);
                return totalFileSize - compressedSize;
            }
            else
            {
                ulong ret = (ulong)(minPlayerVersion.Length + fileEngineVersion.Length + 0x1A);
                if ((flags & 0x100) != 0)
                    return (ret + 0x0A);
                else
                    return (ret + (ulong)signature.Length + 1);
            }
        }
        public uint GetFileDataOffset()
        {
            uint ret = 0;
            if (signature == "UnityArchive")
                return compressedSize;
            else if (signature == "UnityFS" || signature == "UnityWeb")
            {
                ret = (uint)minPlayerVersion.Length + (uint)fileEngineVersion.Length + 0x1A;
                if ((flags & 0x100) != 0)
                    ret += 0x0A;
                else
                    ret += (uint)signature.Length + 1;
            }
            if ((flags & 0x80) == 0)
                ret += compressedSize;
            return ret;
        }
    }
}
