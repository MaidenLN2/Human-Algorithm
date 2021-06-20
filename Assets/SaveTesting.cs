using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTesting
{
    // This section creates the data that we want into the save file
    // The only file types that can be serialised are non-unity-specific types
    // This means int, float, bool, are fine, but Vector3's and Colors aren't

    public int level;
    public int health;
    public float[] position;

    // Constructor function
     public SaveTesting ()
    {

    }
}