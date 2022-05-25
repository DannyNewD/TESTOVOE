
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIMain : MonoBehaviour
{
    [SerializeField] Text lvl;
  
    void Start()
    {
        PrintLvl(SaveData.instance.Level);
        SaveData.instance.LevelChangedEvent += Instance_LevelChangedEvent;
    }

    private void Instance_LevelChangedEvent(int _lvl)
    {
        PrintLvl(_lvl);
    }

    public void PrintLvl(int _lvl) 
    {
        lvl.text = "LVL "+ Convert.ToString(_lvl);
    }

}
