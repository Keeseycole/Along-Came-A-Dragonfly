using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IDSystem : MonoBehaviour
{
    public List<CreatureBase> EarthDefeatedIDs = new List<CreatureBase>();

    public List<CreatureBase> EtherealDefeatedIDs = new List<CreatureBase>();

    public List<CreatureBase> IceDefeatedIDs = new List<CreatureBase>();

    public List<ItemBase> FishIDs = new List<ItemBase>();

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
        else
        {
            return;
        }
    }


    public void addFishID(ItemBase idtoadd)
    {
        if (!FishIDs.Contains(idtoadd))
        {
            FishIDs.Add(idtoadd);

            bestiery.EnableFishEntryButton(ItemBase.ID);
        }
        else
        {
            return;
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
 
}