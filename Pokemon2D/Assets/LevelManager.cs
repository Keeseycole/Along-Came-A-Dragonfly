using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] SceneDetails levelRef;

    [SerializeField] Sprite backround;

    public BoxCollider2D boxCollider;

    public Sprite GetBackround
    {
        get { return backround; }
    }

    [SerializeField] List<CreatureEncounterRecord> creaturesInGrass;
    [SerializeField] List<CreatureEncounterRecord> creaturesInWater;
    [SerializeField] List<CreatureEncounterRecord> creaturesInSnow;
    [SerializeField] List<FishingEncounterRecord> fishInArea;
    [SerializeField] public MusicData musicToPlay;

    public cutsceneManagerr cutscene;


    [HideInInspector]
   [SerializeField] int totalChance = 0;

    int totalChanceWater = 0;

    int totalChanceSnow = 0;

    

    CharecterAnimator charAnim;

    public SceneDetails levelRefs { get { return levelRef; } }

    private void Awake()
    {
        levelRef.SetLevelManager(this);
        cutscene = FindObjectOfType<cutsceneManagerr>();
        CalculateChancePercentage();

        charAnim = FindObjectOfType<CharecterAnimator>();
    }

    private void OnValidate()
    {
        CalculateChancePercentage();
    }

    void CalculateChancePercentage()
    {
        totalChance = -1;
        totalChanceWater = -1;
        totalChanceSnow = -1;

        if (creaturesInGrass.Count > 0)
        {
            totalChance = 0;
            foreach (var record in creaturesInGrass)
            {
                record.lowerChance = totalChance;
                record.upperChance = totalChance + record.chance;

                totalChance = totalChance + record.chance;
            }

            if (creaturesInWater.Count > 0)
            {
                totalChanceWater = 0;
                foreach (var record in creaturesInWater)
                {
                    record.lowerChance = totalChanceWater;
                    record.upperChance = totalChanceWater + record.chance;

                    totalChanceWater = totalChanceWater + record.chance;
                }
            }


            if (creaturesInSnow.Count > 0)
            {
                totalChanceWater = 0;
                foreach (var record in creaturesInSnow)
                {
                    record.lowerChance = totalChanceSnow;
                    record.upperChance = totalChanceSnow + record.chance;

                    totalChanceSnow = totalChanceSnow + record.chance;
                }
            }

        }
    }
    public Creature GetRandomCreature(BattleTrigger trigger)
    {
        var creatureList = (trigger == BattleTrigger.Grasslands) ? creaturesInGrass : creaturesInWater;

        int randomValue = Random.Range(1, 101);
        var creatureRecord = creatureList.First(p => randomValue >= p.lowerChance && randomValue <= p.upperChance);

        var levelRange = creatureRecord.levelRange;
        int level = levelRange.y == 0 ? levelRange.x : Random.Range(levelRange.x, levelRange.y + 1);

        var wildCreature = new Creature(creatureRecord.creature, level);

        wildCreature.Init();
        return wildCreature;


    }

    public ItemBase ItemfromFishing()
    {
        float randomValue = Random.Range(0, 101);
        for (int i = 0; i < fishInArea.Count; i++)
        {
            if (randomValue <= fishInArea[i].chance)
            {
                return fishInArea[i].item;
            }

            randomValue -= fishInArea[i].chance;
        }
        Debug.Log("is Broken");
        return fishInArea[0].item;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var animator = GetComponent<CharecterAnimator>();

        if (collision.tag == "Player")
        {
          //  Debug.Log($"Entered {gameObject.name}");


           StartCoroutine(SceneSystem.EnterLevel(this));

            if (musicToPlay != null)
                AudioManager.i.PlayMusic(musicToPlay, fade: true);


        }

        for (int i = 0; i > cutscene.transform.childCount; i++)
        {
            if (cutscene.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                GetComponent<AudioManager>().MuteMusic();
            } else
            {
                GetComponent<AudioManager>().UnMute();
            }
        }

    }


    
}






[System.Serializable]
public class CreatureEncounterRecord
{
    public CreatureBase creature;
    public Vector2Int levelRange;
    public int chance;

    public float lowerChance { get; set; }
    public float upperChance { get; set; }
}

[System.Serializable]
public class FishingEncounterRecord
{
   
    public ItemBase item;

    [Range(0.1f, 100f)]
    public float chance;

 
}

