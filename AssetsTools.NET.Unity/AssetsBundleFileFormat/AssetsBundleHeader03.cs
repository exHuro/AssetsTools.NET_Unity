namespace AssetsTools.NET.Unity
{
    public class AssetsBundleHeader03
    {
        public string signature;
        public uint fileVersion;
        public string minPlayerVersion;
        public string fileEngineVersion;
        public uint minimumStreamedBytes;
        public uint bundleDataOffs;
        public uint numberOfAssetsToDownload;
        public uint levelCount;
        public AssetsBundleOffsetPair[] pLevelList;
        public uint fileSize2;
        public uint unknown2;
        public byte unknown3;

        public uint bundleCount;
    }
}
