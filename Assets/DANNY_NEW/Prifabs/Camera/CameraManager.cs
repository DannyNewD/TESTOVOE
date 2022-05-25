using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float diraction;
    [SerializeField] AnimationCurve curve;
    [SerializeField] private List<CameraPosition> _cameraPositions = new List<CameraPosition>();
    public Dictionary<CameraPositionState, Transform> cameraPositions = new Dictionary<CameraPositionState, Transform>();

    private CameraPositionState _cameraPositionState;
    public CameraPositionState cameraPositionState
    {
        get
        { 
            return _cameraPositionState;
        }

        set 
        {
            if( _cameraPositionState != value) 
            {
                SetPosition(value);
                _cameraPositionState = value;
            }
        }
    }

    public static CameraManager instance;
    private void Awake()
    {
        instance = this;
        InitializationCameraPositions();
    }

    private void SetPosition(CameraPositionState cameraPosition) 
    {
        mainCamera.DOLocalMove(cameraPositions[cameraPosition].localPosition, diraction).SetEase(curve);
        mainCamera.DOLocalRotateQuaternion(cameraPositions[cameraPosition].localRotation, diraction).SetEase(curve);
    }

    public void InitializationCameraPositions() 
    {
        foreach (var intem in _cameraPositions)
        {
            cameraPositions[intem.key] = intem.val;
        }
    }


    public enum CameraPositionState
    {
        Start,
        Standart,
        Top,
        Finish,      
    }

    [Serializable]
    public class CameraPosition 
    {
        public CameraPositionState key;
        public Transform val;

    }
}
