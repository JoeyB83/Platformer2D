using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveData(SaveFile saveFile)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string whereToSave = Application.persistentDataPath + "/saveData.sav";
        FileStream stream = new FileStream(whereToSave, FileMode.Create);
        formatter.Serialize(stream, saveFile);
        stream.Close();
    }

    public static SaveFile LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string whereToSave = Application.persistentDataPath + "/saveData.sav";

        if (File.Exists(whereToSave))
        {
            FileStream stream = new FileStream(whereToSave, FileMode.Open);
            SaveFile saveFile = (SaveFile)formatter.Deserialize(stream);            
            stream.Close();
            return saveFile;
        }
        else
        {
            SaveFile saveFile = new SaveFile();
            FileStream stream = new FileStream(whereToSave, FileMode.Create);
            formatter.Serialize(stream, saveFile);
            stream.Close();
            return saveFile;
        }
    }
}
