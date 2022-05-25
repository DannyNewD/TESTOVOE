using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockStandart : BlockAbstract, IColorCobe
{
    [SerializeField] public List<CubsColorType> cubsColorType = new List<CubsColorType>();
   

  

    public int GetAllCubeInt()
    {
        int CountCubs=0;
        foreach(var cub in cubsColorType) 
        {
            CountCubs = cub.val.transform.childCount;
        }
        return CountCubs;
    }

    public int GetCobeOnColorInt(LevelGenerator.ColorBlock colorBlok)
    {
        foreach (var cub in cubsColorType)
        {
           if(cub.key == colorBlok) 
            {
               return  cub.val.transform.childCount;
            }
        }
        return 0;
    }

    public void PaintCube(List<LevelGenerator.ColorBlock> colorCube)
    {
        for(int i = 0; i < cubsColorType.Count; i++) 
        {
            cubsColorType[i].key = colorCube[i];

            foreach (Transform Cube in cubsColorType[i].val.transform)
            {
                Cube.gameObject.GetComponent<MeshRenderer>().material = ColorHalper.instance.Get_Material_Block_From_StateColor(colorCube[i]);
                Cube.gameObject.GetComponent<CubeLogics>().colorBlock = colorCube[i];
            }
        }
    }

   
}

[Serializable]
public class CubsColorType 
{
    public LevelGenerator.ColorBlock key;
    public GameObject val;
}
