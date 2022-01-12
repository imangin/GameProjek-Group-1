using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SavingData : MonoBehaviour
{
    private  string DATA_PATH = "/MyGame.dat";
    private Player myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("coin", 0);
        //  PlayerPrefs.SetFloat("helth", 100);
        //  PlayerPrefs.SetString("key", "value");
        // int s = PlayerPrefts.GgetInt("coin");
        // print("Coin is :" + s);
        //SaveData();
        // print("DATA PATH IS " + Applicaton.persistentDataPath + DATA_PATH);

        LoadData();
        if(myPlayer != null)
        {
            print("Player Health: " + myPlayer.Health);
            print("Coin: " + myPlayer.Coin);

        }

    }
    void SaveData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/MyGame.dat");
            Player p = new Player(0, 100);
            bf.Serialize(file, p);
        }catch(Exception e)
        {
            if(e != null)
            {

            }

        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }//savedata
    void LoadData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + DATA_PATH, FileMode.Open);
            myPlayer = bf.Deserialize(file) as Player;
        }catch(Exception e)
        {
            
        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    
}
