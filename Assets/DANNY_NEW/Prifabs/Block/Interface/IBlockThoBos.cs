using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockThoBos 
{
    public void InitializationBoss(int[] lvlsBoss);

    public void FightBos(int lvlPlayr);

    void KickBos(GameObject Boss);

    void GetKilled();
}
