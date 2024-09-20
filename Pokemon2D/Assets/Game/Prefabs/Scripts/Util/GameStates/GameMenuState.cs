using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Utils.StateMachine;

public class GameMenuState : State<GameController>
{
    [SerializeField] MenuController menuComtroller;
    GameController gameController;
    public static GameMenuState i { get; private set; }

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        i = this;
    }
    

    public override void Enter(GameController owner)
    {
        gameController = owner;
        menuComtroller.gameObject.SetActive(true);
        menuComtroller.OnBack += OnBack;
      
    }

  

    public override void Execute()
    {
        menuComtroller.HandleUpdate();
      
    }

    public override void Exit()
    {
        menuComtroller.gameObject.SetActive(false);
        menuComtroller.OnBack -= OnBack;
    }

    void OnBack()
    {
        gameController.StateMachine.Pop();
    }

}
