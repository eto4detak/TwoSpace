﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
    public PlayerData pData = new PlayerData();

    #region Singleton
    static protected SaveLoad s_Instance;
    #endregion

    private SaveLoad()
    {

    }
    public static SaveLoad GetInstance()
    {
        #region Singleton
        if (s_Instance != null)
        {
            return s_Instance;
        }
        s_Instance = new SaveLoad();
        s_Instance.Load();
        return s_Instance;
        #endregion
    }
    
    public void Save(PlayerData toSaved = null)
    {
        if(toSaved == null) toSaved = pData;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, toSaved);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            pData = (PlayerData)bf.Deserialize(file);
            file.Close();
        }
    }
}


[System.Serializable]
public class PlayerData
{
    public int lastLevel;
    public int maxLevel;
    public int cash;
    public int star;
    public bool musicMute;
    public float musicValue;
}
