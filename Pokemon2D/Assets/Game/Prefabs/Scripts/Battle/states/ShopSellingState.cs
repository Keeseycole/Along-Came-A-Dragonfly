using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.StateMachine;

public class ShopSellingState : State<GameController>
{
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] WalletUI walletUI;
    [SerializeField] CountSelectorUI countSelectorUI;
    Inventory inventory;

    public static ShopSellingState i { get; private set; }

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        inventory = Inventory.GetInventory();
    }
    

    public List<ItemBase> itemsAvalible { get; set; }

    bool browseItems = false;

    GameController gc;

    public override void Enter(GameController owner)
    {
        gc = owner;

        browseItems = false;
        StartCoroutine(StartSellingState());
    }

     IEnumerator StartSellingState()
    {
        yield return gc.StateMachine.PushandWait(InventoryState.i);

        var selectItem = InventoryState.i.selectedItem;

        if(selectItem != null)
        {
           yield return SellItem(selectItem);
            StartCoroutine(StartSellingState());
        }
        else
            gc.StateMachine.Pop();
    }

    IEnumerator SellItem(ItemBase item)
    {
   

        if (!item.CanSell)
        {
            yield return DialogueManager.Instance.ShowDialogText("You can't sell that!");
            yield break;
        }

        walletUI.Show();

        float sellingPrice = Mathf.Round(item.Price / 2);
        int countToSell = 1;

        int itemCount = inventory.GetItemCount(item);
        if (itemCount > 1)
        {
            yield return DialogueManager.Instance.ShowDialogText($"How many would you like to sell?",
                waitForInput: false);

            yield return countSelectorUI.ShowSelector(itemCount, sellingPrice,
                (selectedCount) => countToSell = selectedCount);

            DialogueManager.Instance.CloseDialogue();
        }

        sellingPrice = sellingPrice * countToSell;

        int selectedChoice = 0;
        yield return DialogueManager.Instance.ShowDialogText($"I can give you {sellingPrice}g! Would you like to sell?",
            waitForInput: false,
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: choiceIndex => selectedChoice = choiceIndex);

        if (selectedChoice == 0)
        {
            // Yes
            inventory.RemoveItem(item, countToSell);
            Wallet.i.AddMoney(sellingPrice);
            yield return DialogueManager.Instance.ShowDialogText($"You sold {item.Name} for {sellingPrice}g!");
        }
        inventoryUI.gameObject.SetActive(false);
        walletUI.Close();
    }
}
