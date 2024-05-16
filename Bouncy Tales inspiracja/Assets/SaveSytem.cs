using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSytem 
{
  
    // Saving player data to binary file
    public static void SavePlayer(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.XD";
        FileStream stream = new FileStream(path,FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("SAVED");
    }


    // Loading player data from a binary file
    public static PlayerData LoadPlayer()
    {

        string path = Application.persistentDataPath + "/player.XD";

        if(File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode .Open);
            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("SAVE NOT FOUND in " + path);
            return null;
        }
    }


    public static void LvlCompleted(int sceneIndex)
    {
        PlayerData data = LoadPlayer();

        data.level[sceneIndex] = true;
        SavePlayer(data);
    }

    public static void EraseProgress()
    {
        PlayerData data = new PlayerData(0);
        SavePlayer(data);
    }


}
