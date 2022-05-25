using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIGame : MonoBehaviour
{
    [SerializeField] public Text textScore;
    [SerializeField] Text lvl;
    // Start is called before the first frame update
    private void Start()
    {
        PrintScore(SaveData.instance.cubeScore);
        PrintLvl(SaveData.instance.Level);
        SaveData.instance.ScoreChangesEvent += Instance_ScoreChangesEvent;
        SaveData.instance.LevelChangedEvent += Instance_LevelChangedEvent;      
    }

    private void Instance_ScoreChangesEvent(int arg1, int arg2)
    {
        PrintScore(arg2);
    }

    private void Instance_LevelChangedEvent(int _lvl)
    {
        PrintLvl(_lvl);
    }

    private void PrintScore(int _score) 
    {
        textScore.text = Convert.ToString(_score);
    }

    public void PrintLvl(int _lvl)
    {
        lvl.text = "LVL " + Convert.ToString(_lvl);
    }
}
