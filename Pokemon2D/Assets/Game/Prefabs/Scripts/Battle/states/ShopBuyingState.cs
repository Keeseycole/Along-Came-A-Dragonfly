using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils.StateMachine;

public class ShopBuyingState : State<GameController>
{

    [SerializeField] ShopUI shopUI;
    [SerializeField] WalletUI walletUI;
    [SerializeField] CountSelectorUI countSelectorUI;
    [SerializeField] Vector2 cameraOffset;

    Inventory inventory;
    public static ShopBuyingState i { get; private set; }

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        inventory = Inventory.GetInventory();
    }
    //input

    public List<ItemBase> avalibleItems { get; set; }

    bool browseItems = false;

    GameController gc;

    public override void Enter(GameController owner)
    {
        gc = owner;

        browseItems = false;
        StartCoroutine(StartBuyingState());
    }

    public override void Execute()
    {
        if(browseItems)
        shopUI.HandleUpdate();
    }

    IEnumerator StartBuyingState()
    {
        yield return GameController.Instance.MoveCamera(cameraOffset);
        walletUI.Show();
        shopUI.Show(avalibleItems, (item) => StartCoroutine(BuyItem(item)),
            () => StartCoroutine(OnBackFromBuying()));

        browseItems = true;
    }
    IEnumerator BuyItem(ItemBase item)
    {
        browseItems = false;

        yield return DialogueManager.Instance.ShowDialogText("How many would you like to buy?",
            waitForInput: false);

        int countToBuy = 1;
        yield return countSelectorUI.ShowSelector(100, item.Price,
            (selectedCount) => countToBuy = selectedCount);

        DialogueManager.Instance.CloseDialogue();

        float totalPrice = item.Price * countToBuy;

        if (Wallet.i.HasMoney(totalPrice))
        {
            int selectedChoice = 0;
            yield return DialogueManager.Instance.ShowDialogText($"That'll be {totalPrice}",
                waitForInput: false,
                choices: new List<string>() { "Yes", "No" },
                onchoiceSelected: choiceIndex => selectedChoice = choiceIndex);

            if (selectedChoice == 0)
            {
                // Selected Yes
                inventory.AddItem(item, countToBuy);
                Wallet.i.TakeMoney(totalPrice);
                shopUI.Close();
                walletUI.Close();
                yield return DialogueManager.Instance.ShowDialogText("Please come again!");
            }
        }
        else
        {
            yield return DialogueManager.Instance.ShowDialogText("Not enough money!");
        }

        browseItems = true;
    }

    IEnumerator OnBackFromBuying()
    {
        yield return GameController.Instance.MoveCamera(-cameraOffset);
        shopUI.Close();
        walletUI.Close();
        gc.StateMachine.Pop();
    }
}
