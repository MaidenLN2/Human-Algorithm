using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataTest : MonoBehaviour
{
    private int TestReceiver;

    // FixedUpdate is called a set number of times per second - independent of framerate
    private void FixedUpdate()
    {
        TestReceiver = SavedSceneData.Data.Choice01 + 10;
        Debug.Log(TestReceiver);
    }
}
