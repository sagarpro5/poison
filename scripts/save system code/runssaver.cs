using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class runssaver
{
    public static void Saverun(movement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.run";
        FileStream stream = new FileStream(path, FileMode.Create);
        speedrunsave data = new speedrunsave(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static speedrunsave Loadrun()
    {
        string path = Application.persistentDataPath + "/player.run";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            speedrunsave data = formatter.Deserialize(stream) as speedrunsave;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }
}
