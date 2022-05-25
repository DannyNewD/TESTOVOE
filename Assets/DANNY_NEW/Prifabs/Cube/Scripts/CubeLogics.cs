using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeLogics : MonoBehaviour
{
    [SerializeField] public LevelGenerator.ColorBlock colorBlock;  

    public void Blow() 
    {
        this.gameObject.transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            Destroy(this.gameObject); //TODO: Better through the pool  });
        });
    }
}
