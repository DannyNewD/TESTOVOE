using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] Transform ContenerBlock;

  
    public void Restart()
    {
        ClearLevelBlocks();
        PrintLevel(SaveData.instance.Level);
    }

    private void ClearLevelBlocks() 
    {
        foreach(Transform child in ContenerBlock) 
        {
            Destroy(child.gameObject); //TODO: Here I would implement a pool of objects.
        }
    }

    private void PrintLevel(int LVL) 
    {
       levelGenerator.GenerLevel(LVL);
    }

 //   private void 
}
