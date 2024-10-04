using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxPartySlotUI : MonoBehaviour
{
    [SerializeField] Text nameText;

    [SerializeField] Text lvlText;

    [SerializeField] Image image;

    public void SetData(Creature creature)
    {
        nameText.text = creature.Base.name;
        lvlText.text = "" + creature.Level;
        image.sprite = creature.Base.RightSprite;
        image.color = new Color(255, 255, 255, 100);
    }

    public void ClearData()
    {
        nameText.text = "";
        lvlText.text = "";
        image.sprite = null;
        image.color = new Color(255, 255, 255, 0);
    }
}
