using System;
using System.Collections.Generic;

public interface IBlockColorSwitch
{
    public List<LevelGenerator.ColorBlock> SwitchColors { get; set; }

    public void GateRendering(List<LevelGenerator.ColorBlock> colorGate);

    public void SetColorPlayr(int index);

    void SwitchColor(LevelGenerator.ColorBlock CorectColor);
 
}
