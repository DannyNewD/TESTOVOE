using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputInfo", menuName = "ScriptableObjects/InputInfo")]
public class InputInfo : ScriptableObject
{
    

    [Space]
    [Header("Input")]
    [SerializeField] private float _Intensity = 8;
    public float Intensity => this._Intensity;


    [Space]
    [Header("Move")]
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _PositionÑonstraintLeft = -3.2f;
    [SerializeField] private float _PositionÑonstraintRight = 3.2f;

    public float speed => this._speed;
    public float PositionÑonstraintLeft => this._PositionÑonstraintLeft;
    public float PositionÑonstraintRight => this._PositionÑonstraintRight;


    [Space]
    [Header("Rotate")]
    [SerializeField] private float _timeDilay = 1;
    [SerializeField] private float _SpeedRotate = 10;

    public float timeDilay => this._timeDilay;
    public float SpeedRotate => this._SpeedRotate;

    [Space]
    [Header("ForwardMovement")]
    [SerializeField] private float _speedForwardMovement;
    [SerializeField] private Vector3 _DirectionForwardMovement = new Vector3(0,0,20);

    public float speedForwardMovement => this._speedForwardMovement;
    public Vector3 DirectionForwardMovement => this._DirectionForwardMovement;

}
