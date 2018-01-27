namespace AssetsTools.NET.Unity
{
    public struct AssetsFileHeader
    {
        public uint metadataSize;
        public uint fileSize;
        public uint format;
        public uint offs_firstFile;
        public uint endianness;
        public byte[] unknown;
        
        public ulong Read(ulong absFilePos, AssetsFileReader reader)
        {
            metadataSize = reader.ReadUInt32();
            fileSize = reader.ReadUInt32();
            format = reader.ReadUInt32();
            offs_firstFile = reader.ReadUInt32();
            endianness = reader.ReadByte();
            reader.bigEndian = endianness == 1 ? true : false;
            unknown = reader.ReadBytes(3);
            return reader.Position;
        }
    }
}
