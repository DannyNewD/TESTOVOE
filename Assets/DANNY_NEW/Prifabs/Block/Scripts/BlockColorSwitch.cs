using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockColorSwitch : BlockAbstract, IBlockColorSwitch
{
    public GameObject[] Gats = new GameObject[2];
    public List<LevelGenerator.ColorBlock> SwitchColors { get; set; }

    public void GateRendering(List<LevelGenerator.ColorBlock> colorGate)
    {
        SwitchColors = colorGate;
        if (colorGate.Count == 2) 
        {
            Gats[0].gameObject.GetComponent<MeshRenderer>().material = ColorHalper.instance.Get_Material_Gate_From_StateColor(colorGate[0]);
            Gats[1].gameObject.GetComponent<MeshRenderer>().material = ColorHalper.instance.Get_Material_Gate_From_StateColor(colorGate[1]);
        }
    }


    public void SetColorPlayr(int index)
    {        
            SwitchColor(SwitchColors[index]);       
    }

    public void SwitchColor(LevelGenerator.ColorBlock CorectColor)
    {
        InputPlayer.instance.Playr.GetComponent<PlayerLogick>().ChangePlayerColor(CorectColor);       
    }

   
}
