using System;
using System.IO;

namespace AssetsTools.NET.Unity
{
    public class AssetsFile
    {
        public AssetsFileHeader header;
        public TypeTree typeTree;

        public PreloadList preloadTable;
        public AssetsFileDependencyList dependencies;

        public uint AssetTablePos;
        public uint AssetCount;

        public AssetsFileReader reader;
        public Stream readerPar;

        public AssetsFile(AssetsFileReader reader)
        {
            this.reader = reader;
            readerPar = reader.BaseStream;
            header = new AssetsFileHeader();
            header.Read(0, reader);
            typeTree = new TypeTree();
            typeTree.Read(reader.Position, reader, header.format, reader.bigEndian);
            AssetCount = reader.ReadUInt32();
            reader.Align();
            AssetTablePos = Convert.ToUInt32(reader.BaseStream.Position);
            reader.BaseStream.Position += AssetFileInfo.GetSize(header.format) * AssetCount;
            preloadTable = new PreloadList();
            preloadTable.Read(reader.Position, reader, header.format, reader.bigEndian);
            dependencies = new AssetsFileDependencyList();
            dependencies.Read(reader.Position, reader, header.format, reader.bigEndian);
        }
    }
}
