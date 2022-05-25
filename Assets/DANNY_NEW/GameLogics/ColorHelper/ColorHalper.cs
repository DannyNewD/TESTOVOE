using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHalper : MonoBehaviour
{
    [SerializeField] private Material defaultMaterialsBlock;
    [SerializeField] private Material[] materialsBlocks;

    [SerializeField] private Material delaultMaterialGate;
    [SerializeField] private Material[] materialsGate;

    public static ColorHalper instance;
    private void Awake()
    {
        instance = this;
    }

    public Material Get_Material_Gate_From_StateColor(LevelGenerator.ColorBlock colorGate) 
    {
        switch (colorGate)
        {
            case LevelGenerator.ColorBlock.Blue:
                return materialsGate[0];
            case LevelGenerator.ColorBlock.Green:
                return materialsGate[1];
            case LevelGenerator.ColorBlock.Red:
                return materialsGate[2];
            case LevelGenerator.ColorBlock.Yellow:
                return materialsGate[3];
        }
        return delaultMaterialGate;
    }

    public Material Get_Material_Block_From_StateColor(LevelGenerator.ColorBlock colorBlock)
    {
        switch (colorBlock) 
        {
            case LevelGenerator.ColorBlock.Blue:
                return materialsBlocks[0];
            case LevelGenerator.ColorBlock.Green:
                return materialsBlocks[1];
            case LevelGenerator.ColorBlock.Red:
                return materialsBlocks[2];
            case LevelGenerator.ColorBlock.Yellow:
                return materialsBlocks[3];
        }
        return defaultMaterialsBlock;
    }
}
