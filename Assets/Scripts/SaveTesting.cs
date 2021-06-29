using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTesting
{
    // This section creates the data that we want into the save file
    // The only file types that can be serialised are non-unity-specific types
    // This means int, float, bool, are fine, but Vector3's and Colors aren't

    public int Choice01 = -1;
    public int Choice02 = -1;
    public int Choice03 = -1;
    public int Choice04 = -1;
    public int Choice05 = -1;
    public int Choice06 = -1;
    public int Choice07 = -1;

    // Constructor function
    public SaveTesting (SavedSceneData SceneData)
    {
        Choice01 = SceneData.Choice01;
        Choice02 = SceneData.Choice02;
        Choice03 = SceneData.Choice03;
        Choice04 = SceneData.Choice04;
        Choice05 = SceneData.Choice05;
        Choice06 = SceneData.Choice06;
        Choice07 = SceneData.Choice07;
    }
}