using System.IO;
using UnityEngine;

public static class DataSaving 
{

    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/saves/";
    public static readonly string FILE_EXT = ".json";
    public static void Save(string filename, string dataToSave)
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }

        File.WriteAllText(SAVE_FOLDER + filename + FILE_EXT, dataToSave);
    }

    public static string Load(string filename) 
    {
        string fileLocation = SAVE_FOLDER + filename + FILE_EXT;
        if(File.Exists(fileLocation))
        {
            string loadData = File.ReadAllText(fileLocation);

            return loadData;
        }
        else
        {
            return null;
        }
    }
}
