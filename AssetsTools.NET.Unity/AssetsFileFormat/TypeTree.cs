namespace AssetsTools.NET.Unity
{
    public struct TypeTree
    {
        public string unityVersion;
        public uint version;
        public bool hasTypeTree;
        public uint fieldCount;

        public Type_0D[] pTypes_Unity5;
        public Type_07[] pTypes_Unity4;

        public uint dwUnknown;
        public uint _fmt;

        public ulong Read(ulong absFilePos, AssetsFileReader reader, uint version, bool bigEndian)
        {
            unityVersion = reader.ReadNullTerminated();
            this.version = reader.ReadUInt32();
            hasTypeTree = reader.ReadBoolean();
            fieldCount = reader.ReadUInt32();
            pTypes_Unity5 = new Type_0D[fieldCount];
            for (int i = 0; i < fieldCount; i++)
            {
                Type_0D type0d = new Type_0D();
                type0d.Read(hasTypeTree, reader.Position, reader, version, version, bigEndian);
                pTypes_Unity5[i] = type0d;
            }
            if (version < 0x0E) dwUnknown = reader.ReadUInt32();
            _fmt = version;
            return reader.Position;
        }
    }
}
