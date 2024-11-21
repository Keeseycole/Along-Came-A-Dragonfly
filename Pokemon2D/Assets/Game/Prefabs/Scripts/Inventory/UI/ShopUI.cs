using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject itemList;
    [SerializeField] ItemSlotUI itemSlotUI;

    [SerializeField] Image itemIcon;
    [SerializeField] Text itemdesc;

    int selectedItem;

    RectTransform itemListRect;

    [SerializeField] Image upArrow, downarrow;

    List<ItemBase> avalibleItems;

    List<ItemSlotUI> slotUIList;

    Action<ItemBase> onItemSelected;

    Action onBack;

    const int itemsInViewport = 8;




    private void Awake()
    {
        
        itemListRect = itemList.GetComponent<RectTransform>();
    }

    public void Show(List<ItemBase> avalibleItems, Action<ItemBase> onItemSelected, Action onBack)
    {
     
        this.avalibleItems = avalibleItems;
        this.onItemSelected = onItemSelected;
        this.onBack = onBack;

        gameObject.SetActive(true);
        UpdateItemList();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void HandleUpdate()
    {
        Enter();


        var prevSelection = selectedItem;

        if (Input.GetKeyDown(KeyCode.S))
            ++selectedItem;
        else if (Input.GetKeyDown(KeyCode.W))
            --selectedItem;

        selectedItem = Mathf.Clamp(selectedItem, 0, avalibleItems.Count - 1);

        if (selectedItem != prevSelection)
        {
            UpdateItemSelection();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            onItemSelected?.Invoke(avalibleItems[selectedItem]);
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            onBack?.Invoke();
    }

    void UpdateItemList()
    {
        foreach (Transform child in itemList.transform)
            Destroy(child.gameObject);

        slotUIList = new List<ItemSlotUI>();

        foreach (var item in avalibleItems)
        {
            var slotuiObj = Instantiate(itemSlotUI, itemList.transform);
            slotuiObj.SetNameAndPrice(item);

            slotUIList.Add(slotuiObj);
        }
        UpdateItemSelection();

    }

    void UpdateItemSelection()
    {
        

        selectedItem = Mathf.Clamp(selectedItem, 0, avalibleItems.Count - 1);

        for (int i = 0; i < slotUIList.Count; i++)
        {
          //  if (i == selectedItem)
           //     slotUIList[i].Nametext.color = GlobalSettings.i.HighlightedColor;
           // else
             //   slotUIList[i].Nametext.color = Color.black;
        }

        if (avalibleItems.Count > 0)
        {
            var item = avalibleItems[selectedItem];
            itemIcon.sprite = item.Icon;
            itemdesc.text = item.Description;
        }

        UpdateButtonNav();
        EventSystem.current.SetSelectedGameObject(slotUIList[0].gameObject);
    }


    public void Enter(int currentButton = 0)
    {

        EventSystem.current.SetSelectedGameObject(slotUIList[currentButton].gameObject);
    }
    void UpdateButtonNav()
    {
        List<Button> buttons = new List<Button>();

        foreach (ItemSlotUI Uibutton in slotUIList.Where(b => b.gameObject.activeInHierarchy))
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
                
            });

        }

        if (buttons.Count <= 1)
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
            if (i == 0)
            {
                nav.selectOnUp = buttons[buttons.Count - 1];
                nav.selectOnDown = buttons[i + 1];
            }
            else if (i == buttons.Count - 1)
            {
                nav.selectOnUp = buttons[i - 1];
                nav.selectOnDown = buttons[0];
            }
            else
            {
                nav.selectOnUp = buttons[i - 1];
                nav.selectOnDown = buttons[i + 1];
            }
            buttons[i].navigation = nav;
        }
    }

    }
