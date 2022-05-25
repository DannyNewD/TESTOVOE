using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using DG.Tweening;


public class InputPlayer : MonoBehaviour
{
    [Space]
    [Header("Elements")]
    [SerializeField] public Transform Playr;

    [Space]
    [Header("Settings")]
    [SerializeField] public InputInfo inputInfo;



    public static InputPlayer instance;
    private void Awake()
    {
        instance = this;

        width = (float)Screen.width / 100f;

        if(inputInfo == null) 
        {
            inputInfo = Resources.Load<InputInfo>("Info/DefaultInput");
        }
    } 

    private void Update()
    {
        InputUdate();
        PlayrRotate();
    }
    private void FixedUpdate()
    {
        PlayrUpdateMove();
        ForwardMovement();
    }


    
    private bool _isRunning = false;
    public bool isRunning 
    {
        get 
        { 
            return _isRunning; 
        } 
        set 
        { 
            _isRunning = value;
        }
    }


    private void ForwardMovement() 
    {
        if (isRunning) 
        {
            Playr.transform.Translate(inputInfo.DirectionForwardMovement * Time.deltaTime/ inputInfo.speedForwardMovement, Space.Self);
        }
    }



    private float timerPlayrRotate;
    private void PlayrUpdateMove() 
    {
        if (Input.touchCount > 0 && isInput)
        {
            if (Playr.transform.localPosition.x > inputInfo.Position—onstraintLeft) Playr.transform.localPosition = new Vector3(inputInfo.Position—onstraintLeft, Playr.transform.localPosition.y, Playr.transform.localPosition.z); 
            if (Playr.transform.localPosition.x < inputInfo.Position—onstraintRight) Playr.transform.localPosition = new Vector3(inputInfo.Position—onstraintRight, Playr.transform.localPosition.y, Playr.transform.localPosition.z); 
            Playr.transform.localPosition = Vector3.Lerp(Playr.localPosition, new Vector3(PlayrSatrtPositionX + (FingerMovementsDifference / inputInfo.Intensity), Playr.localPosition.y, Playr.localPosition.z), Time.deltaTime * inputInfo.speed);   
        }      
    }



    private float TiltAngle;
    float durationR;
    private void PlayrRotate() 
    {
        timerPlayrRotate += Time.deltaTime;
        if (timerPlayrRotate > inputInfo.timeDilay)
        {
            TiltAngle = ((int)((durationR - FingerMovementsDifference) * 100)) / 500f * inputInfo.SpeedRotate;          
            durationR = FingerMovementsDifference;
            timerPlayrRotate = 0;
            Playr.transform.DOLocalRotate(new Vector3(0, TiltAngle * -1.5f, 0), 0.5f);
        }
    }



    private float PlayrSatrtPositionX;
    private float width;
    private float PercentShift;
    private Vector3 positionInput;
    private float FingerMovementsDifference;
    private float StartP;
    bool isIU = true;
    private bool _isInput = true;
    public bool isInput
    {
        get
        {
            return _isInput;
        }
        set
        {
            _isInput = value;
        }
    }

    private void InputUdate()
    {
        if(Input.touchCount > 0 && isInput) 
        {
            positionInput = Input.GetTouch(0).position;
            PercentShift = positionInput.x / width;        
            if (isIU == true) 
            {
                UIManager.instance.corectScreen = UIManager.Screen.UIGame;
                GameCore.instance.behaviourGame = GameCore.BehaviourGame.PlayGame;
                _isRunning = true;
                isIU = false;
                StartP = PercentShift;         
                PlayrSatrtPositionX = Playr.position.x;
            }
            FingerMovementsDifference = PercentShift - StartP;
        }
        else
        {
            if(isIU == false) 
            {
                isIU = true;             
                if (Playr.transform.localPosition.x > inputInfo.Position—onstraintLeft)  Playr.transform.DOLocalMoveX(inputInfo.Position—onstraintLeft, 0.5f); 
                if (Playr.transform.localPosition.x < inputInfo.Position—onstraintRight)  Playr.transform.DOLocalMoveX(inputInfo.Position—onstraintRight, 0.5f);              
            }          
        }
    }

    public void StopGame() 
    {
        isRunning = false;
        isInput = false;
    }

    public void PrepareForLaunch() 
    {
        isInput = true;
    }


}
