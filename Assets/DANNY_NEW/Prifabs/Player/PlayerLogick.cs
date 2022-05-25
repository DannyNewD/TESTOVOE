using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerLogick : MonoBehaviour
{
    public AnimationCurve animationCurve;
    private int scoreCube = 0;
    private float startSize = 1;

    [SerializeField] private float transformationSpeed;
    [SerializeField] LevelGenerator.ColorBlock CorrectColor;


    private void Awake()
    {
        startSize = this.gameObject.transform.localScale.x;
    }
    public void ChangePlayerColor(LevelGenerator.ColorBlock Òolor—hangeable)  
    {
        CorrectColor = Òolor—hangeable;    
        this.gameObject.GetComponent<MeshRenderer>().material.DOColor(ColorHalper.instance.Get_Material_Block_From_StateColor(Òolor—hangeable).color, 1);
    }

    public void ResetPlayer()
    {
        scoreCube = 0;
        this.gameObject.transform.DOScale(1, 0.1f);
        this.gameObject.transform.position = new Vector3(0, this.gameObject.transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube") 
        {
            if (other.gameObject.GetComponent<CubeLogics>().colorBlock == CorrectColor)
            {
                SetScoreCube(1);
            }
            else 
            {
                SetScoreCube(-1);
            }
            other.gameObject.GetComponent<CubeLogics>().Blow();
        }
    }

    private void SetScoreCube(int direction) 
    {
        switch (direction) 
        {
            case 1:

                if (scoreCube < 10)
                {

                    SetSize(scoreCube);
                   
                   
                }
                scoreCube++;
                SaveData.instance.cubeScore = scoreCube;
                break;


            case -1:

                if(scoreCube != 0) 
                {
                    SetSize(scoreCube);
                    scoreCube--;
                    SaveData.instance.cubeScore = scoreCube;
                }
                break;
        }
    }

    private void SetSize(int direction)
    {
        if (scoreCube < 9) 
        {
            float size = startSize + ((startSize / 10) * (scoreCube + direction));
            this.gameObject.transform.DOScale(size, transformationSpeed).SetEase(animationCurve); 
        }
    }  
}
