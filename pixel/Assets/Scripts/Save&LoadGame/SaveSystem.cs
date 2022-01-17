using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerHealth(PlayerGetDamage health)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Playerhealth.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData Health = new PlayerData(health);
        formatter.Serialize(stream, Health);
        Debug.Log("Save Successful " + path);
        stream.Close();
    }
    public static void SavePlayerCoin(CoinsScript coin)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerCoin.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData Coin = new PlayerData(coin);
        formatter.Serialize(stream, Coin);
        Debug.Log("Save Successful " + path);
        stream.Close();
    }

    public static PlayerData LoadPlayerHealth()
    {
        string path = Application.persistentDataPath + "/Playerhealth.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Load Successful " + path);
            return data;
        }
        else
        {
            Debug.LogError("khong tim thay file save " + path);
            return null;
        }
    }
    public static PlayerData LoadPlayerCoin()
    {
        string path = Application.persistentDataPath + "/PlayerCoin.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Load Successful " + path);
            return data;
        }
        else
        {
            Debug.LogError("khong tim thay file save " + path);
            return null;
        }
    }
}
