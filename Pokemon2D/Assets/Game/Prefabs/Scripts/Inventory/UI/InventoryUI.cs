using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Utils.GenericSelection;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.EventSystems;

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

   [SerializeField] InventoryState inventoryState;

    const int itemsInViewport = 8;

    

    int selectedCatagory = 0;

    List<ItemSlotUI> slotUIList = new List<ItemSlotUI>();

    InventoryUIState state;

   
    private void Awake()
    {
        inventory = Inventory.GetInventory();
        itemListRect = itemList.GetComponent<RectTransform>();
        Debug.Log("Item list Rect", itemListRect.gameObject);
        ItemSlotUI[] components = itemListRect.GetComponentsInChildren<ItemSlotUI>(true);

        foreach (ItemSlotUI component in components)
        {
            slotUIList.Add(component);
        }

    }

    private void Start()
    {

        UpdateItemList();

        inventory.OnUpdated += UpdateItemList;

      
    }

    void UpdateItemList()
    {
        // Clear all the existing items
        Debug.Log("UpdateItemList");
        foreach (ItemSlotUI child in slotUIList)
         child.gameObject.SetActive(false);

       List<ItemSlot> currentList = inventory.GetSlotsByCatagory(selectedCatagory);

        int i = 0;
        foreach (ItemSlot itemSlot in currentList)
        {
            ItemSlotUI slotUIObj;

            if (i >= slotUIList.Count)
            {
                 slotUIObj = Instantiate(itemSlotUI, itemList.transform);
                slotUIList.Add(slotUIObj);
            } else
            {
                slotUIObj = slotUIList[i];
                slotUIObj.gameObject.SetActive(true);
            }
          
           

            int k = i;

            slotUIObj.SetData(itemSlot, () => 
            {   ShowItem(itemSlot.Item);
                selectedItem = k;
              
            });
          
            
           
           
            i++;
        }
        SetItems(slotUIList.Select(s => s.GetComponent<TextSlot>()).ToList());

        UpdateSelectionUI();
        UpdateButtonNav();
        EventSystem.current.SetSelectedGameObject(slotUIList[0].gameObject);
    }



    public override void HandleUpdate()
    {

        int prevSelection = selectedItem;
        //UnityEngine.Debug.Log("Update UI");
        if (onMenuTimer < 1f) return;
        if (state == InventoryUIState.ItemSelection)
        {
            selectedItem = Mathf.Clamp(selectedItem, 0, inventory.GetSlotsByCatagory(selectedCatagory).Count);

            if (prevSelection != selectedItem)
            {
                UpdateSelectionUI();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // Debug.Log("Pressed Space");
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
        Debug.Log("Open Party Screen");
        state = InventoryUIState.PartySelection;
        partyScreen.gameObject.SetActive(true);
    }

    public void ShowItem(ItemBase item)
    {
        itemIcon.sprite = item.Icon;
        itemdesc.text = item.Description;
    }

     void UpdateButtonNav()
    {
        List<Button> buttons = new List<Button>();
        
        foreach(ItemSlotUI Uibutton in slotUIList.Where(b => b.gameObject.activeInHierarchy))
        {
            buttons.Add(Uibutton.GetComponent<Button>());
            
        }

        int k = 0;

        for (int i = 0; i < buttons.Count; i++)
        {
            k = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => 
            { 
                Debug.Log("Button Pressed");
                inventoryState.OnItemSelected(k);
            }); 
            
        }

        if(buttons.Count <= 1)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Navigation nav = buttons[i].navigation;
                nav.selectOnUp = null;
                nav.selectOnDown = null;
                buttons[i].navigation = nav;
            }
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            Navigation nav = buttons[i].navigation;
            if(i == 0) 
            {
                nav.selectOnUp = buttons[buttons.Count - 1];
                nav.selectOnDown = buttons[i + 1];
            } else if (i == buttons.Count - 1) 
            { 
                nav.selectOnUp = buttons[i - 1];
                nav.selectOnDown= buttons[0];
            } else
            {
                nav.selectOnUp = buttons[i - 1];
                nav.selectOnDown = buttons[i + 1];
            }
            buttons[i].navigation = nav;
        }
    }

    public ItemBase SelectedItem => inventory.GetItem(selectedItem, selectedCatagory);
}
