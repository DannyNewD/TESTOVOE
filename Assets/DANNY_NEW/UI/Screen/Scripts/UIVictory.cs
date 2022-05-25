using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIVictory : MonoBehaviour
{
    [Space]
    [Header("UIElement")]
    [SerializeField] private Text Score;
    [SerializeField] private Button contin;
    [SerializeField] private Text Lvl;
    private void Awake()
    {
        contin.onClick.AddListener(() => 
        {
            SaveData.instance.cubeScore = 0;
            SaveData.instance.Level++;
            SaveData.instance.SaveGameData();
            UIManager.instance.corectScreen = UIManager.Screen.UIMain;
            GameCore.instance.behaviourGame = GameCore.BehaviourGame.MainStart;
        });
    }

    private void Start()
    {
        Lvl.text = Convert.ToString("Victory! LVL " + SaveData.instance.Level);
        Score.text = Convert.ToString(SaveData.instance.cubeScore);
    }
}
