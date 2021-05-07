//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using UnityEditor;

public class Bundle_Builder:Editor
{
    [MenuItem ("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(@"/Users/sachinjha/Desktop/Asset",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.StandaloneOSX);
    }
}
