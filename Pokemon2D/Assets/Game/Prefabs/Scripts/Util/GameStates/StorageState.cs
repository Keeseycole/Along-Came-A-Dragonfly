using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.StateMachine;

public class StorageState : State<BattleSystem>
{
    [SerializeField] StorageUI storageui;
    public static StorageState i { get; private set; }

    private void Awake()
    {
        i= this;
    }

    public override void Enter(BattleSystem owner)
    {
        storageui.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        storageui.gameObject.SetActive(false);
    }
}
