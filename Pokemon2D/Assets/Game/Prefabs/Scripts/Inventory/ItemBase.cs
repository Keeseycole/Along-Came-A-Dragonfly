using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Fish
}
public class ItemBase : ScriptableObject
{
    
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] ItemType itemType;
    [SerializeField] float price;
    [SerializeField] bool canSell;

    [SerializeField]  public int dropChance;


    //for fish
   [SerializeField] public static int ID;

    public virtual string Name => name;

    public string Description => description;

    public Sprite Icon => icon;

    public float Price => price;

    public bool CanSell => canSell;

    public virtual bool Use(Creature creature)
    {
        return false;
    }

    public ItemType GetItemType => itemType;
    
    public virtual bool CanUseInBattle => true;
    public virtual bool CanUseOutsideBattle => true;

    public bool IsReusable { get; internal set; }
}
