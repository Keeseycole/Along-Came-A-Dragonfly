using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Utils.GenericSelection;
using System.Diagnostics;

public enum InventoryUIState 
{ 
    ItemSelection,
    PartySelection,
    Busy
}
public class InventoryUI : SelectionUI<TextSlot>
{
    [SerializeField] GameObject itemList;
    [SerializeField] ItemSlotUI itemSlotUI;

   
    [SerializeField] Image itemIcon;
    [SerializeField] Text itemdesc;

    [SerializeField] Text catagoryText;


    [SerializeField] PartyScreen partyScreen;

    [SerializeField] Image upArrow, downarrow;

    Action<ItemBase> onItemUsed;

    GameController gc;

    RectTransform itemListRect;
    Inventory inventory;



    const int itemsInViewport = 8;

    

    int selectedCatagory = 0;
    InventoryUIState state;

    List<ItemSlotUI> slotUIList;
    private void Awake()
    {
        inventory = Inventory.GetInventory();
        itemListRect = itemList.GetComponent<RectTransform>();
    }

    private void Start()
    {
        UpdateItemList();

        inventory.OnUpdated += UpdateItemList;


    }

    void UpdateItemList()
    {
        // Clear all the existing items
        foreach (Transform child in itemList.transform)
         Destroy(child.gameObject);

        slotUIList = new List<ItemSlotUI>();

        int i = 0;
        foreach (var itemSlot in inventory.GetSlotsByCatagory(selectedCatagory))
        {

          
            var slotUIObj = Instantiate(itemSlotUI, itemList.transform);

            int k = i;

            slotUIObj.SetData(itemSlot, () => 
            {   ShowItem(itemSlot.Item);
                selectedItem = k;
              
            });
          
            slotUIList.Add(slotUIObj);
           
           
            i++;
        }
        SetItems(slotUIList.Select(s => s.GetComponent<TextSlot>()).ToList());

        UpdateSelectionUI();

    }



    public override void HandleUpdate()
    {

        int prevSelection = selectedItem;
        UnityEngine.Debug.Log("Update UI");

        if (state == InventoryUIState.ItemSelection)
        {
            selectedItem = Mathf.Clamp(selectedItem, 0, inventory.GetSlotsByCatagory(selectedCatagory).Count);

            if (prevSelection != selectedItem)
            {
                UpdateSelectionUI();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OpenPartyScreen();
            }
          //  else if (Input.GetKeyDown(KeyCode.LeftShift))
         //   {
          //      onback.Invoke();
          //  }

        }
        base.HandleUpdate();
    }

    public override void UpdateSelectionUI()
    {
        base.UpdateSelectionUI();

        var slots = inventory.GetSlotsByCatagory(selectedCatagory);
        
        if (slots.Count > 0)
        {
            ShowItem(slots[selectedItem].Item);
        }

    }

   

    void OpenPartyScreen()
    {
        state = InventoryUIState.PartySelection;
        partyScreen.gameObject.SetActive(true);
    }

    public void ShowItem(ItemBase item)
    {
        itemIcon.sprite = item.Icon;
        itemdesc.text = item.Description;
    }

    public ItemBase SelectedItem => inventory.GetItem(selectedItem, selectedCatagory);
}
