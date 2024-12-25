using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IDSystem : MonoBehaviour
{
    public List<CreatureBase> EarthDefeatedIDs = new List<CreatureBase>();

    public List<CreatureBase> WaterDefeatedIDs = new List<CreatureBase>();

    public List<CreatureBase> EtherealDefeatedIDs = new List<CreatureBase>();

    public List<CreatureBase> IceDefeatedIDs = new List<CreatureBase>();

    public List<int> FishIDs = new List<int>();

    [Header("Bestiery")]
    [SerializeField] Beastiery bestiery;


    CreatureBase creature;

    public static IDSystem i;

    private void Awake()
    {
        i = this;
    }

    public void addIceCreatureID(CreatureBase idtoAdd)
    {
        if (!IceDefeatedIDs.Contains(idtoAdd))
        {
            IceDefeatedIDs.Add(idtoAdd);
            creature = idtoAdd;
            bestiery.EnableIceEntryButton(creature.ID);
        }
       
    }


    public void addFishID(FishItem idtoAdd)
    {
        Debug.Log("addFish");
        if (!FishIDs.Contains(idtoAdd.ID))
        {
            FishIDs.Add(idtoAdd.ID);

            bestiery.EnableFishEntryButton(idtoAdd.ID);
        }
      
    }
    public void addEarthCreatureID(CreatureBase idtoAdd)
    {
        if (!EarthDefeatedIDs.Contains(idtoAdd))
        {
            EarthDefeatedIDs.Add(idtoAdd);
            creature = idtoAdd;
            bestiery.EnableEarthEntryButton(creature.ID);
        }
        else
        {
            return;
        }

    }

    public void addEatherealCreatureID(CreatureBase idtoAdd)
    {
        if (!EtherealDefeatedIDs.Contains(idtoAdd))
        {
            EtherealDefeatedIDs.Add(idtoAdd);
            creature = idtoAdd;
            bestiery.EnableEtherealEntryButton(creature.ID);
        }
        else
        {
            return;
        }

    }

    public void addWaterCreatureID(CreatureBase idtoAdd)
    {
        if (!WaterDefeatedIDs.Contains(idtoAdd))
        {
            WaterDefeatedIDs.Add(idtoAdd);
            creature = idtoAdd;
            bestiery.EnableWaterEntryButton(creature.ID);
        }
        else
        {
            return;
        }

    }

}