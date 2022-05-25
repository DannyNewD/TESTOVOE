using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    [SerializeField] private PlayerLogick playrLogick;
    private LevelManager levelManager;
    public static GameCore instance;
    private void Awake()
    {
        instance = this;

        

        SaveData.instance.GetGameData();
      
        levelManager = this.gameObject.GetComponent<LevelManager>();
        behaviourGame = BehaviourGame.MainStart;
    }

    private BehaviourGame _behaviourGame;
    public BehaviourGame behaviourGame 
    {
        get
        {
            return _behaviourGame; 
        }
        set 
        { 
            if(_behaviourGame == BehaviourGame.MainStart && value == BehaviourGame.PlayGame) 
            {
                StartGame();
            }
            if(_behaviourGame == BehaviourGame.PlayGame && value == BehaviourGame.InactiveGame) 
            {
                GameOver();
            }
            if(_behaviourGame == BehaviourGame.InactiveGame && value == BehaviourGame.MainStart) 
            {
                Relaunch();
            }
         
            _behaviourGame = value; 
        } 
    }

  

    private void StartGame() 
    {
        
    }

    private void GameOver() 
    {
        InputPlayer.instance.StopGame();
        UIManager.instance.corectScreen = UIManager.Screen.UIVictory;
    }

    private void Relaunch() 
    {
        playrLogick.ResetPlayer();
        //     InputPlayr.instance.PrepareForLaunch();
        InputPrepareForLaunch();
        levelManager.Restart();
        
    }

    public async void InputPrepareForLaunch() 
    {
        await Task.Delay(500);
        InputPlayer.instance.PrepareForLaunch();
    }

    public enum BehaviourGame 
    {
        InactiveGame = 0, 
        PlayGame = 1,
        MainStart = 2
    }
}
