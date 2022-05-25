using System.Collections.Generic;

public interface IColorCobe 
{
   
    public void PaintCube(List<LevelGenerator.ColorBlock> colorCube);
    public int GetAllCubeInt();
    public int GetCobeOnColorInt(LevelGenerator.ColorBlock colorBlok);
}
