using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    private void Awake()
    {
        instance = this;
        GetGameData();

       
    }


    private int _cubeScore;
    public int cubeScore {
        get 
        {
            return _cubeScore;
        } 
        set 
        {

            ScoreChangesEvent?.Invoke(_cubeScore, value);
            _cubeScore = value;
        } 
    }
    public event Action<int, int> ScoreChangesEvent; //<int,int> OLD NEW


    private int _level = 1;
    public int Level {
        get 
        {
            return _level;
        } 
        set 
        {
            LevelChangedEvent?.Invoke(value); 
            _level = value; 
        } 
    }
    public event Action<int> LevelChangedEvent;


    public void SaveGameData() 
    {
        PlayerPrefs.SetInt("level", Level);
        PlayerPrefs.Save();
    }
    public void GetGameData() 
    {
        if (PlayerPrefs.HasKey("level")) 
        {
            Level = PlayerPrefs.GetInt("level");
            if (Level == 0)
            {
                PlayerPrefs.SetInt("level", 1);
                Level = 1;
            }
        }
        else 
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }
    }


    private void OnApplicationQuit()
    {
        SaveGameData();
    }

  /*private void OnApplicationPause(bool pause)
    {
        SaveGameData();
    }*/

}
