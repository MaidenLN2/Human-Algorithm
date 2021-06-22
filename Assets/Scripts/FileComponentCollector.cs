using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileComponentCollector : MonoBehaviour
{
    private GameObject DataStorage;
    private SavedSceneData SceneData;

    void Awake()
    {
        DataStorage = GameObject.Find("SceneData");
        SceneData = DataStorage.GetComponent<SavedSceneData>();
    }

    public void Save()
    {
        SceneData.SaveToFile();
    }

    public void Load()
    {
        SceneData.LoadFromFile();
    }
}