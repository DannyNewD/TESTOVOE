using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BlockTypesInfo", menuName = "ScriptableObjects/BlockTypesInfo")]
[Serializable]
public class BlockTypesInfo : ScriptableObject
{
    [Space]
    [Header("Blocks")]
    [SerializeField] private GameObject[] _blocks;
    public GameObject[] blocks => this._blocks;


    [Header("Sett")]
    [SerializeField] private LevelGenerator.LevelType _levelType;
    public LevelGenerator.LevelType levelType => this._levelType;
}
