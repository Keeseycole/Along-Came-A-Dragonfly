using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyMemberUI : MonoBehaviour
{
    [SerializeField] Text nametext, levelText;
    [SerializeField] HPBar hpBar;
    

   // public Button[] memberButtons;

    private void Start()
    {
     if(nametext == null)
        {
            Debug.LogError("This obj missing Name text reference", this.gameObject);
        }

        if (levelText == null)
        {
            Debug.LogError("This obj missing Lvl text reference", this.gameObject);
        }


        if (hpBar == null)
        {
            Debug.LogError("This obj missing HP Bar reference", this.gameObject);
        }
    }
   

    Creature _creature;
    public void Init(Creature creature)
    {
        _creature = creature;
        UpdateData();
        

        _creature.OnHPChanged += UpdateData;
    }

    void UpdateData()
    {
        nametext.text = _creature.Base.Name;
    
        levelText.text = "Level: " + _creature.Level;
        hpBar.SetHP((float)_creature.HP / _creature.MaxHP);
    }

    public void SetSelected(bool selected)
    {
        if(selected)
            nametext.color = GlobalSettings.i.HighlighedColor;
            else
                nametext.color = Color.black;
        
    }

  

}
