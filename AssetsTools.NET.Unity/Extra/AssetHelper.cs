namespace AssetsTools.NET.Unity.Extra
{
    public static class AssetHelper
    {
        public static ClassDatabaseType FindAssetClassByID(ClassDatabaseFile classDatabaseFile, uint id)
        {
            foreach (ClassDatabaseType type in classDatabaseFile.classes)
            {
                if (type.classId == id)
                    return type;
            }
            return null;
        }

        public static ClassDatabaseType FindAssetClassByName(ClassDatabaseFile classDatabaseFile, string name)
        {
            foreach (ClassDatabaseType type in classDatabaseFile.classes)
            {
                if (type.name.GetString(classDatabaseFile) == name)
                    return type;
            }
            return null;
        }
    }
}
