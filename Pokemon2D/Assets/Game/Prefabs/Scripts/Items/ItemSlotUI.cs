using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : TextSlot, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
 
    [SerializeField] Text countText;

    Action onHover;

    protected override void Start()
    {
        base.Start();


        if (countText == null)
        {
            Debug.LogError("This obj count text reference", this.gameObject);
        }
    }

   
    public float Hight => GetComponent<RectTransform>().rect.height;
    public void SetData(ItemSlot itemslot, Action onHover)
    {
        this.onHover = onHover;
        text.text = itemslot.Item.Name;
        countText.text = $"X{itemslot.Count}";
    }
    public void SetNameAndPrice(ItemBase item)
    {
       
        text.text = item.Name;
        countText.text = $"{item.Price}g";
    }

    public new void OnSelect(BaseEventData eventData)
    {
        onHover?.Invoke();
        Debug.Log("Onselect called");
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover?.Invoke();
        Debug.Log("Hovering Over item");
    }
}
