namespace AssetsTools.NET.Unity
{
    public struct AssetsFileDependencyList
    {
        public uint dependencyCount;
        public AssetsFileDependency[] pDependencies;
        public ulong Read(ulong absFilePos, AssetsFileReader reader, uint format, bool bigEndian)
        {
            dependencyCount = reader.ReadUInt32();
            pDependencies = new AssetsFileDependency[dependencyCount];
            for (int i = 0; i < dependencyCount; i++)
            {
                AssetsFileDependency dependency = new AssetsFileDependency();
                dependency.Read(reader.Position, reader, bigEndian);
                pDependencies[i] = dependency;
            }
            return reader.Position;
        }
    }
}
