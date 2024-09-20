using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utils.GenericSelection;

public class MoveSelectionUI : SelectionUI<TextSlot>
{
    [SerializeField] Button[] MagicButtons;

    [SerializeField] Text mpText;

    Creature _moves;

    private void Start()
    {
        SetSelectionSettings(SelectionType.Grid, 3);
    }

    public override void UpdateSelectionUI()
    {
        base.UpdateSelectionUI();

        var move = _moves;

        UpdateMP(move);

    }

   public void UpdateMP(Creature creatureMp)
    {
        mpText.text = $"MP: {creatureMp.MP}/{creatureMp.MaxMP}";
    }
}
