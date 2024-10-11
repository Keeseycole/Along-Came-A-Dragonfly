using System.Collections;
using System.Collections.Generic;
using UnityEngine;





 [CreateAssetMenu(menuName = "Items/create New Fish")]
public class FishItem : ItemBase
{

    public int ID;

    public FishItem() 
    {
        itemType = ItemType.Fish; 
    }
}
