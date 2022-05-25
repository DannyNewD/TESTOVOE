using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//behaviour TODO Clener;

public class UIManager : MonoBehaviour
{
    [Space]
    [Header("Screen")]
    [SerializeField] GameObject ContenerScreen;
    [SerializeField] UIMain UI_Main_Screen;
    [SerializeField] UILose UI_Lose_Screen;
    [SerializeField] UIGame UI_Game_Screen;
    [SerializeField] UIVictory UI_Victory_Screen;


    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CloseAll();
        corectScreen = Screen.UIMain;
    }

    private Screen _corectScreen;
    public Screen corectScreen 
    {
        get 
        {
            return _corectScreen;
        } 
        set 
        { 
            if(_corectScreen != value) 
            {
                ScreenChangesEvent?.Invoke(value);
                Convart_Screen_To_GameObject(_corectScreen).SetActive(false);
                Convart_Screen_To_GameObject(value).SetActive(true);
                _corectScreen = value;
            }         
        } 
    }
    public event Action<Screen> ScreenChangesEvent;


    public void SetScreen(Screen screen) 
    {
        corectScreen = screen;
    }


    private GameObject Convart_Screen_To_GameObject(Screen screen) 
    {
        switch (screen) 
        {
            case Screen.UIGame: return UI_Game_Screen.gameObject;        
            case Screen.UILose: return UI_Lose_Screen.gameObject;
            case Screen.UIMain: return UI_Main_Screen.gameObject;
            case Screen.UIVictory: return UI_Victory_Screen.gameObject;
        }
        return null;
    }



    public void CloseAll()
    {
        foreach(Transform screen in ContenerScreen.transform) 
        {
            screen.gameObject.SetActive(false);
        }
    }
 

    public enum Screen
    {
        UIGame,
        UIMain,
        UIVictory,
        UILose,
       
    }
}
