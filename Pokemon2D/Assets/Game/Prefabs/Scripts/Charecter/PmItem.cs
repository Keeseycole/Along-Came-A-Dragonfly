using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/create New PLayer Move")]
public class PmItem : ItemBase
{

    [SerializeField] MoveBase movesToUnlock;
 
    public MoveBase getPlayerMoves() 
    { 
        return movesToUnlock;
    }
}
