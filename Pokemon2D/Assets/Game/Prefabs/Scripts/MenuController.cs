
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.GenericSelection;

public class MenuController : SelectionUI<TextSlot>
{
    [SerializeField] Button[] menuButtons;
   
    [SerializeField] BattleSystem BS;

    [SerializeField] GameObject beastUI;

    GameController gc;

    public GameObject menu;
    private void Start()
    {
        
        SetItems(GetComponentsInChildren<TextSlot>().ToList());
        ButtonInit();


    }


    void ButtonInit()
    {

        Enter();

        menuButtons[0].onClick.AddListener(() =>
        {
            
            StartCoroutine(BS.GoToPartyState());
            
        });

        menuButtons[1].onClick.AddListener(() => {
            
            StartCoroutine(BS.GoToInventoryState());
        });

        menuButtons[2].onClick.AddListener(() => {
            
            //gc.StateMachine.Push(BeastieryState.i);
        });

        menuButtons[3].onClick.AddListener(() => {

            SavingSystem.i.Save("SaveSlot1");
        });

        menuButtons[4].onClick.AddListener(() => {
            SavingSystem.i.Load("SaveSlot1");

        });

        

    }

    public void Enter(int currentButton = 0)
    {
       
        EventSystem.current.SetSelectedGameObject(menuButtons[currentButton].gameObject);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        gc.StateMachine.Pop();
    }

}
