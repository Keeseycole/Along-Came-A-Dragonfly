using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingState : Utils.StateMachine.State<GameController>
{
    public PlayerController player;
    public static FishingState i { get; private set; }

    public GameObject fishingUI;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();

      

        i = this;
    }

    GameController gameController;

    public override void Enter(GameController owner)
    {
        gameController = owner;
    }
    public override void Execute()
    {
        player.i.HandleUpdate();

    }

  

}
