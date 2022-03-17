
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveManager
{

    public static void SaveData()
    {


        BinaryFormatter formatter = new BinaryFormatter();
        string FileName = Application.persistentDataPath + "player.bin";
        FileStream stream = new FileStream(FileName, FileMode.Create);

        formatter.Serialize(stream, ScorData.Scor);
        formatter.Serialize(stream, ScorData.Health);
        stream.Close();



    }


    public static void LoadData()
    {

        string FileName = Application.persistentDataPath + "player.bin";

        if (File.Exists(FileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(FileName, FileMode.Open);
            ScorData.Scor = (int)formatter.Deserialize(stream);
            ScorData.Health = (int)formatter.Deserialize(stream);
            stream.Close();

        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(FileName, FileMode.Create);

            formatter.Serialize(stream, ScorData.Scor);
            formatter.Serialize(stream, ScorData.Health);
            stream.Close();
        }


       


    }

}
