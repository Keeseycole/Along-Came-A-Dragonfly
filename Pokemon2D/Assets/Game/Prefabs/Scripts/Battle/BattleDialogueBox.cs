using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.GenericSelection;

public class BattleDialogueBox : MonoBehaviour
{
   
    [SerializeField] GameObject BattledialogueBox;
    [SerializeField] GameObject moveSelector;
    [SerializeField] Color highlightedColor;

    [SerializeField] Button[] actionButtons;
   
    
    [SerializeField] Text mpText;

    [SerializeField] Text mpCostText;

    [SerializeField] List<MoveTextSlot> theButtons = new List<MoveTextSlot>();

    BattleSystem battleSystem;

    

    Creature creature;

    private void Awake()
    {
        battleSystem= FindObjectOfType<BattleSystem>();

       
    }
    public void EnableActionSelector(bool enabled)
    {
        BattledialogueBox.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
    }

    
    public void UpdateMoveSelection( Move move)
    {
       
        mpCostText.text = $"Cost: {move.MPCost} MP";
    }

    public void UpdateMP(Creature creatureMp)
    {
        mpText.text = $"MP: {creatureMp.MP}/{creatureMp.MaxMP}";
    }
   

    public void UpdateMoveList(List<Move> newMoveList)
    {
        Debug.Log("Update Move", gameObject);
        for (int i = 0; i < theButtons.Count; i++)
        {
            int k;
            k = i + 1;
            if (i < newMoveList.Count - 1)
            {
                theButtons[i].GetButtonComponent.onClick.RemoveAllListeners();
                theButtons[i].gameObject.SetActive(true);
                theButtons[i].SetCurrentMove(newMoveList[k]);
                theButtons[i].GetButtonComponent.onClick.AddListener(() =>

                {
                //battleSystem.CheckMoveMP(newMoveList[k]);
                  
                 StartCoroutine(RunTurnState.i.RunTurns(BattleAction.Move, k));
                    moveSelector.SetActive(false);
                    Debug.Log($"using move");

                });
                theButtons[i].updateMPcost += UpdateMoveSelection;

            }
            else
            {
                theButtons[i].gameObject.SetActive(false);
              
            }
        }

       
    }


    public void Enter(int currentButton = 0)
    {
        EnableMoveSelector(true);

        EventSystem.current.SetSelectedGameObject(theButtons[currentButton].gameObject);
    }
}
