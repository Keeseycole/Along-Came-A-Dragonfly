using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSelection;
using Utils.StateMachine;

public enum BeastieryUIState
{
    HabitateSelection,
    CreatureSelectState,
    Busy
}
public class BeastieryUI : State<GameController>
{

    [SerializeField] BeastieryUIState beastieryUI;

   

   

}
