using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.GenericSelection;
using Utils.StateMachine;

public class MoveSelectionState : State<BattleSystem>
{
    [SerializeField] MoveSelectionUI magicSelectionUI;

    [SerializeField] GameObject mpText;
    [SerializeField] GameObject mpcostText;
    [SerializeField] Button[] theButtons;

    //SelectionUI selectionUI;

    public static MoveSelectionState i { get; private set; }


    public List<Move> Moves { get;  set; }


    private void Awake()
    {
        i = this;
    }
    public  void Enter()
    {


      //  selectionUI.SetMoves(Moves);

        magicSelectionUI.gameObject.SetActive(true);
     //   selectionUI.OnSelected += OnMoveSelected;
      //  selectionUI.OnBack += OnBack;

        

        mpText.SetActive(true);
        mpcostText.SetActive(true);

        EventSystem.current.SetSelectedGameObject(theButtons[0].gameObject);
    }

    public  void UpdateMovesList( List<Move> newMoveList)
    {
        for (int i = 0; i < theButtons.Length; i++)
        {
            if(i <= newMoveList.Count)
            {
                theButtons[i].gameObject.SetActive(true);
               // theButtons[i].SetText(newMoveList[i].Base.name);
                theButtons[i].onClick.AddListener(() =>
                {
                    Debug.Log($"move Clicked{i} ");
                   
                });
            } else
            {
                theButtons[i].gameObject.SetActive(false);
            }
        }

    }

   // public override void Exit()
    //{
       // selectionUI.gameObject.SetActive(false);
       // selectionUI.OnSelected -= OnMoveSelected;
       // selectionUI.OnBack -= OnBack;

      //  selectionUI.ClearItems();

   //     mpText.SetActive(false);
  //      mpcostText.SetActive(false);
   // }

  //  void OnMoveSelected(int selection)
  //  {
   //     bs.SelectedMove = selection;
   //     bs.StateMachine.ChangeState(RunTurnState.i);
   // }

    void OnBack()
    {
       // bs.StateMachine.ChangeState(ActionSelectionState.i);
    }
}
