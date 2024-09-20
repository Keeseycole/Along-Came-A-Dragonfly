using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{

    public Sprite ItemSprite;

    public string itemName;
    public int dropChance;
 

    public Loot(string itemName, int dropChance)
    {
        this.itemName = itemName;
        this.dropChance = dropChance;
    }
}
