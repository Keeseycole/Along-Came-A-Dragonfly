
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class TextSlot : MonoBehaviour,  ISelectHandler, IDeselectHandler
{ 
    [SerializeField] protected Text text;

    Color originalColor;


     protected virtual void Start()
    {

        originalColor = text.color;
        if(text == null)
        {
            Debug.LogError("This obj missing text reference", this.gameObject);
        }
    }
    public void SetText(string s)
    {
      
        text.text = s;
    }

    public  void OnSelect(BaseEventData eventData)
    {
      
        text.color = GlobalSettings.i.HighlighedColor;
    }

    public  void OnDeselect(BaseEventData eventData)
    {
        text.color = originalColor;
    }

    

}
