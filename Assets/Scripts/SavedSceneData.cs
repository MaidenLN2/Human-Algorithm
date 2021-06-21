using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SavedSceneData : MonoBehaviour
{
    // Inter-scene variable transfer is being done through a singleton static variable in this way because:
    // - Single static variables are inflexible when it comes to images and more complex variable types
    // - PlayerPrefs require the use of an external file that may or may not be specific to the operating system and I would like to keep this as system agnostic as possible

    // Create a singleton variable that stores everything that we want to transfer into each scene
    public static SavedSceneData Data = null;

    // All of the information that we want to store will be in variables belonging to this singleton "class"
    // This will need to be copied over to the 
    public int TestInteger = 5;

    // Runs upon creation and sets the variable to not be deleted when a new scene is loaded
    private void Awake()
    {
        if (Data == null)
        {
            Data = this;
        }
        else if (Data != this)
        {
            Destroy(gameObject);
        }

        TestInteger = 5;

        DontDestroyOnLoad(Data.gameObject);
    }

    public void SaveToFile()
    {
        SaveSystem.SaveSceneData(this);
    }

    public void LoadFromFile()
    {
        SaveTesting data = SaveSystem.LoadSceneData();

        TestInteger = data.TestInteger;
    }
}
