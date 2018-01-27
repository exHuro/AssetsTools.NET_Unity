namespace AssetsTools.NET.Unity
{
    public struct AssetsFileDependency
    {
        public byte[] bufferedPath;
        public struct GUID128
        {
            public long mostSignificant;
            public long leastSignificant;
            public ulong Read(ulong absFilePos, AssetsFileReader reader)
            {
                mostSignificant = reader.ReadInt64();
                leastSignificant = reader.ReadInt64();
                return reader.Position;
            }
        }
        public GUID128 guid;
        public int type;
        public string assetPath;
        public ulong Read(ulong absFilePos, AssetsFileReader reader, bool bigEndian)
        {
            guid = new GUID128();
            guid.Read(reader.Position, reader);
            bufferedPath = new byte[] { reader.ReadByte() }; //todo: why
            type = reader.ReadInt32();
            assetPath = reader.ReadNullTerminated();
            if (assetPath.StartsWith("library/"))
            {
                assetPath = "Resources\\" + assetPath.Substring(8);
            }
            return reader.Position;
        }
    }
}
