namespace AssetsTools.NET.Unity
{
    public struct TypeField_0D
    {
        public ushort version;
        public byte depth;
        public bool isArray;
        public uint typeStringOffset;
        public uint nameStringOffset;
        public uint size;
        public uint index;
        public uint flags;
        public ulong Read(ulong absFilePos, AssetsFileReader reader, bool bigEndian)
        {
            version = reader.ReadUInt16();
            depth = reader.ReadByte();
            isArray = reader.ReadBoolean();
            typeStringOffset = reader.ReadUInt16();
            reader.ReadUInt16();
            nameStringOffset = reader.ReadUInt16();
            reader.ReadUInt16();
            size = reader.ReadUInt32();
            index = reader.ReadUInt32();
            flags = reader.ReadUInt32();
            return reader.Position;
        }
    }
}
