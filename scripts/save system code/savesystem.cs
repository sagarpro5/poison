using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class savesystem
{
    public static void saveplayer(movement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.score";
        FileStream stream = new FileStream(path, FileMode.Create);
        playerdata data = new playerdata(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static playerdata loadplayer()
    {
        string path = Application.persistentDataPath + "/player.score";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            playerdata data = formatter.Deserialize(stream) as playerdata;
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
