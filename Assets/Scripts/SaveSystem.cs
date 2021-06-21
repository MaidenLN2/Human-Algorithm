using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveSceneData(SavedSceneData DataToSave)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveTesting data = new SaveTesting(DataToSave);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveTesting LoadSceneData()
    {
        string path = Application.persistentDataPath + "/savedata.txt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveTesting data = formatter.Deserialize(stream) as SaveTesting;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
