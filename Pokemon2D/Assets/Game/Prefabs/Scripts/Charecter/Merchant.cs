using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] List<ItemBase> avalibleItems;
  public IEnumerator Trade()
    {
        ShopMenuState.i.Avalibleitems = avalibleItems;
        yield return GameController.Instance.StateMachine.PushandWait(ShopMenuState.i);
    }

    public List<ItemBase> AvalibleItems => avalibleItems;
}
