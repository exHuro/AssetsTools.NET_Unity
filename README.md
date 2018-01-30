# AssetsTools.NET for Unity Projects
A special version of AssetsTools.NET that you can use in your Unity Projects.

Currently only supports U5.6.0f3.

## Usage
#### Loading a file
The easiest way to manage loading multiple files is to use AssetsManager:
```cs
public AssetsManager assetsManager;
public void Sample() {
	string assetRootDir = "pathToFolderWithAssetsFile";
	using (FileStream assetStream = new FileStream("pathToAssetsFile", FileMode.Open)) {
		assetsManager = new AssetsManager();
		assetsManager.LoadAssets(assetStream, assetRootDir);
		assetsManager.LoadClassFile(Path.Combine(Application.StartupPath, "cldb.dat"));
	}
}
```

This will load all dependencies on the assets file. It also loads the class file which you can get from UABE by (Options => Edit Type Database => classdata.tpk => uncheck compress the file and export U5.6.0f3).

From here you can find an asset by its id and reading a property.

```cs
public AssetsManager assetsManager;
public void Sample() {
	...
	
    AssetFileInfoEx afi = assetsManager.initialTable.getAssetInfo(5);
    AssetTypeInstance ati = assetsManager.GetATI(assetsManager.file, afi);
    
    MessageBox.Show(ati.GetBaseField().Get("m_Name").GetValue().AsString());
    
	assetsManager.file.Close();
	assetsManager.classFile.Close();
	foreach (AssetsManager.Dependency dep in assetsManager.dependencies)
		dep.file.Close();
}
```
[Chrck out the original here!](https://github.com/DerPopo/UABE)
