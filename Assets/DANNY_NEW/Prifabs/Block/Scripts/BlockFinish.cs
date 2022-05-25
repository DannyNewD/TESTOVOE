using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFinish : BlockAbstract
{
    [SerializeField] GameCore gameCore;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            gameCore.behaviourGame = GameCore.BehaviourGame.InactiveGame;
            OnTrigerCamera();
            
        }
    }

   
}
