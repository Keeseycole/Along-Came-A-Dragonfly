using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.StateMachine;

public class ShopMenuState : State<GameController> 
{
  public static ShopMenuState i { get; private set; }

    private void Awake()
    {
        i = this;
    }

    //input

    public List<ItemBase> Avalibleitems { get; set; }

    GameController gc;

    public override void Enter(GameController owner)
    {
        gc = owner;

        StartCoroutine(StartMenuState());
    }

    IEnumerator StartMenuState()
    {
      

        int selectedChoice = 0;
        yield return DialogueManager.Instance.ShowDialogText("Welcome",
            waitForInput: false,
            choices: new List<string>() { "Buy", "Sell", "Quit" },
            onchoiceSelected: choiceIndex => selectedChoice = choiceIndex);

        if (selectedChoice == 0)
        {
            // Buy
            ShopBuyingState.i.avalibleItems = Avalibleitems;
            yield return gc.StateMachine.PushandWait(ShopBuyingState.i);
        }
        else if (selectedChoice == 1)
        {
            // Sell
          
          yield return gc.StateMachine.PushandWait(ShopSellingState.i);
        }
        else if (selectedChoice == 2)
        {
            // Quit
           
        }
        gc.StateMachine.Pop();
    }

}
