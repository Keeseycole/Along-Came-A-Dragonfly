using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootChance : MonoBehaviour
{
   
    public ItemBase droppedItem;
    public List<ScriptableObject> lootlist;


   public ItemBase GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<ItemBase> possibleItems = new List<ItemBase>();

        foreach (ItemBase item in lootlist)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

            if(possibleItems.Count > 0) 
            { 
                ItemBase droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
                return droppedItem;
            }
            // dropped nothing
            return null;
        
    }

 
      
    
}
