namespace AssetsTools.NET.Unity
{
    public struct PreloadList
    {
        public uint len;
        public AssetPPtr[] items;

        public ulong Read(ulong absFilePos, AssetsFileReader reader, uint format, bool bigEndian)
        {
            len = reader.ReadUInt32();
            items = new AssetPPtr[len];
            for (int i = 0; i < len; i++)
            {
                items[i].fileID = reader.ReadUInt32();
                items[i].pathID = reader.ReadUInt64();
            }
            return reader.Position;
        }
    }
}
