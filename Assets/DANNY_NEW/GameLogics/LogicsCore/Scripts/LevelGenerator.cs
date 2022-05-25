using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

[Serializable]
public class LevelGenerator : MonoBehaviour
{
    [Space]
    [Header("Player")]
    [SerializeField] PlayerLogick Player;

    [Space]
    [Header("Block")]
    [SerializeField] GameObject StartBlock;
    [SerializeField] GameObject FinishBlock;
    [SerializeField] Transform ContenerBlocks;
    private float OldSizeZ;
    private float OldPosZ;

    [Space]
    [Header("LevelTypes")]
    [SerializeField] public Dictionary<LevelType, BlockTypesInfo> DifficultyTypes = new Dictionary<LevelType, BlockTypesInfo>();// = new Dictionary<LevelType, BlockTypesInfo>();
    [SerializeField] private List<DifficultyTypes> _DifficultyTypes = new List<DifficultyTypes>();
    private BlockTypesInfo DefaultDifficultyTypes = null;
    private BlockTypesInfo CorrectTypes = null;

    //Lvl Data
   

    private void Awake()
    {
        LevelTypeInitialization();
        OldSizeZ = StartBlock.transform.localScale.z;
    }

    private void Start()
    {

    }

    public void LevelTypeInitialization() 
    {
        foreach (var intem in _DifficultyTypes)
        {
            DifficultyTypes[intem.key] = intem.val;
        }

        if (DifficultyTypes == null || DifficultyTypes.Count == 0)
        {
            DefaultDifficultyTypes = Resources.Load<BlockTypesInfo>("Info/Default_DifficultyTypes_Info");
            DifficultyTypes.Add(LevelType.None, DefaultDifficultyTypes);
        }
    }

    public void GenerLevel(int lvl)
    {
        OldPosZ = 0;
        OldSizeZ = StartBlock.transform.localScale.z; 
        StartCoroutine(GenerLevelCoroutine(lvl, GetLevelType(lvl)));
    }

    public LevelType GetLevelType(int lvl) //TODO: Implement non-algorithm
    {
        if(DefaultDifficultyTypes == null) 
        {
            if (lvl == 1) return LevelType.Default;
                if(lvl % 2 == 0) 
                {
                    return LevelType.Default;
                }
                else 
                {
                    if(lvl % 5 == 0) 
                    {
                        return LevelType.Coins;
                    }
                    else 
                    {
                        return LevelType.Hard;
                    }
                }
        }
        return LevelType.None;

    }



    private int QuantityСubes = 0; //Количество кубов
    private int PossibleQuantityСubes = 0; //Количество подходящих кубов. Это может пригодиться для логики сражения с босами или если уровень нужно пройти относительно реального количества кубов.
    private ColorBlock StartColor; //Стартовый цвет. 
    private ColorBlock[] PossibleСolors = new ColorBlock[2]; //Один из возможных цветов который выбрал юзер. Этот пораметр нужен для того чтобы не вышло что генеряться блоки не того цвета что юзер.
    public IEnumerator GenerLevelCoroutine(int lvl, LevelType levelType, Action action = null) 
    {
        yield return null;
        Random.seed = lvl;
     

        PossibleСolors[0] = (ColorBlock)Random.Range(0, 4);//Определяем возможные стартовые цвета для
        PossibleСolors[1] = (ColorBlock)Random.Range(0, 4);

        StartColor = PossibleСolors[Random.Range(0, PossibleСolors.Length)];//Рандомный цвет плеера
        Player.ChangePlayerColor(StartColor);

        CorrectTypes = DifficultyTypes[levelType];//Определяем сложность уровня
        int ScaleLvl = Random.Range(12, 26);//Определяем длину уровня

        for(int i = 0; i < ScaleLvl; i++) 
        {
            Transform CorectBlock = CorrectTypes.blocks[Random.Range(0, CorrectTypes.blocks.Length)].transform;
            GameObject Obj = Instantiate(CorectBlock.gameObject, ContenerBlocks);
            Obj.transform.localPosition = new Vector3(CorectBlock.localPosition.x, CorectBlock.localPosition.y, OldPosZ + (CorectBlock.localScale.z/2) + (OldSizeZ/2)); //Растовляем расчитываеться от  размера придыдущего блока и актуального + растояние на котором стоял придыдущий блок
            OldPosZ = Obj.transform.localPosition.z;
            OldSizeZ = Obj.transform.localScale.z; //Запоминаем последнии позиции
            CustomizeBlock(Obj); //Логика настройки в зависимости от типа блока и его возмождных плюшек.
           
        }
        FinishBlock.transform.localPosition = new Vector3(FinishBlock.transform.localPosition.x, FinishBlock.transform.localPosition.y, OldPosZ + (FinishBlock.transform.localScale.z / 2) + (OldSizeZ / 2));

    }

    public void CustomizeBlock(GameObject blok) 
    {
        if (blok.GetComponent<IBlockThoBos>() != null) 
        {
            //TODO: Add logic for bosses.
        }

        if (blok.GetComponent<IColorCobe>() != null)
        {
            List<ColorBlock> PaintColors = new List<ColorBlock>();
            int NumberLines =  blok.GetComponent<BlockStandart>().cubsColorType.Count;

            for(int i = 0; i < NumberLines; i++) 
            {
                PaintColors.Add((ColorBlock)Random.Range(0, 4));
            }

            PaintColors[Random.Range(0, NumberLines)] = PossibleСolors[Random.Range(0, PossibleСolors.Length)];

            blok.GetComponent<IColorCobe>().PaintCube(PaintColors);
        }

        if (blok.GetComponent<IBlockStandart>() != null)
        {
           //Может быть такое что сейчас не нужна настройка для стандартных блоков. Но расширев это можно сделать тут. 
        }

        if (blok.GetComponent<IBlockEvent>() != null)
        {
            
        }

        if (blok.GetComponent<IBlockColorSwitch>() != null)
        {
            
            PossibleСolors[0] = (ColorBlock)Random.Range(0, 4);
            PossibleСolors[1] = (ColorBlock)Random.Range(0, 4);
            blok.GetComponent<IBlockColorSwitch>().GateRendering(PossibleСolors.ToList());
        }

       
    }


    public enum ColorBlock 
    {
        Blue = 0,
        Green = 1,
        Yellow = 2,
        Red = 3,
    }

    public enum LevelType 
    {
        None,
        Default,
        Hard,
        Coins,
    }
}

[Serializable] 
public class DifficultyTypes
{
    public LevelGenerator.LevelType key;
    public BlockTypesInfo val;
}


