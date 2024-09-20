using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Habitates
{
    Fire,
    Water,
    Earth,
    Ice,
    Darkness,
    Etharial
}

[CreateAssetMenu(fileName = "Creature", menuName = "Creature/Create New")]
public class CreatureBase : ScriptableObject
{
    [SerializeField] string name;

    public int ID;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;

    [SerializeField] CreatureType type1;
  

    [SerializeField] Habitates creatureHabitates;

    //base stats

    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int maxhp;
   // [SerializeField] int spAttack;
   // [SerializeField] int spDefense;
    [SerializeField] int speed;
    [SerializeField] int maxMp;
    [SerializeField] int currentmp;

    [SerializeField] int expGain;
    [SerializeField] GrowthRate growthRate;

    [SerializeField] int catchRate = 255;

    public const int maxMoves = 10;

    [SerializeField] List<LearnableMoves> learnableMoves;
    [SerializeField] List<MoveBase> learnableByItems;

    [SerializeField] List<Evolution> evolutions;

    [SerializeField] public CreatureBase instance;

    [SerializeField] public Vector2 creatureSize;

    [SerializeField] public Vector2 mouthPos;


    public bool isDefeted;

    public bool isEarth, isFire, isWater,isIce, isDarkness, isEthareal;
    private void Awake()
    {
        instance= this; 
    }
    public int GetExpForLevel(int level)
    {
        if(growthRate == GrowthRate.Fast)
        {
            return 4 * (level * level * level) / 5;
        }
        else if (growthRate == GrowthRate.MediumFast)
        {
            return level * level * level;
        }

        return -1;
    }
    public string Name
    {
        get { return name; }
    }

    public Vector2 Creaturesize
    {
        get { return creatureSize; }
    }

    public Vector2 MouthPos
    {
        get { return mouthPos; }
    }

    public string Description { 
        
        get { return description; } 
    }
    public Sprite Leftsprite
    {
        get { return leftSprite; }
    }

    public Sprite RightSprite
    {
        get { return rightSprite; }
    }
    public CreatureType Type1
    {
        get { return type1; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int MaxHP
    {
        get { return maxhp; }
    }
    public int MaxMP
    {
        get { return maxMp; }
    }

    public int CurrentMP
    {
        get { return currentmp; }
    }

    public List<LearnableMoves> LearnableMoves
    {
        get { return learnableMoves; }
    }

    public List<MoveBase> LearnableByItems => learnableByItems;

    public List<Evolution> Evolutions => evolutions;

   // public int SpAttack
   // {
    //    get { return spAttack; }
  //  }

 //   public int SpDefense
  //  {
   //     get { return spDefense; }
   // }

    public int Speed
    {
        get { return speed; }
    }

    public int CatchRate => catchRate;

    public int ExpGain => expGain;

    public GrowthRate GrowthRate => growthRate;

    public Habitates getHabitate { get { return creatureHabitates; } }

}

[System.Serializable] 
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base {
        get { return moveBase; }

        }

    public int Level
    {
        get { return level; }
    }
}

[System.Serializable]
public class Evolution
{
    [SerializeField] CreatureBase evolveInto;
    [SerializeField] int requiredLevel;
    [SerializeField] ItemBase requiredItem;

    public CreatureBase EvolveInto => evolveInto;
    public int RequiredLevel => requiredLevel;

    public ItemBase RequiredItem => requiredItem;
}
public enum CreatureType
{
    normal,
    fire,
    water,
    darkness,
    ice,
    earth,
    ethareal
}

public enum GrowthRate
{
    Fast,
    MediumFast,
}
public enum Stat
{
    Attack,
    Defense,
    SpDefense,
    SpAttack,
    Speed,

    // to boost move accuracy
    Accuracy,
    Evasion,
    
}



public class TypeChart
{
   static float[][] chart =
    {
          //Attack Type ->   Nor    Fire    Water    Dark     Ice      Earth  Ethareal   

       /* NOR*/ new float [] {1f,    1f,     1f,      1f,     1f,       1f,     .5f},
       /* FIR*/ new float [] {1f,   .5f,     1.3f,    1f,     1f,       1f,     .7f},
       /* WAT*/ new float [] {1f,   1.3f,   .5f,      1f,     1f,       1f,     .6f},
      /* Dark*/ new float [] {1.5f, 1.5f,   1.5f,     1f,     1f,       1f,      1f},
       /* Ice*/ new float [] {1f,   1.3f,   .5f,      1f,     1f,       1f,      .7f},
     /* Earth*/ new float [] {1f,   1.3f,   .5f,      1f,     1f,       1f,      .6f},
   /*Etharial*/ new float [] {2f,    2f,     2f,     2.3f,    2f,       2f,       1f}
    };

    public static float GetEffectivness(CreatureType attackType, CreatureType defenseType)
    {
        if (attackType == CreatureType.normal || defenseType == CreatureType.normal)
            return 1f;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}