using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.StateMachine;

public class BeastieryState : State<GameController>
{
    [SerializeField] BeastieryUI bestieryui;
    public static BeastieryState i { get; private set; }

    private void Awake()
    {
        i = this;
    }

    public override void Enter(GameController owner)
    {
        bestieryui.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        bestieryui.gameObject.SetActive(false);
    }
}
