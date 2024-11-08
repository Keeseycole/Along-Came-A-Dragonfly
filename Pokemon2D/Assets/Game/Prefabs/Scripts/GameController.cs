using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Utils.StateMachine;








public enum GameState { FreeRoam, Battle, Dialog, Menu, PartyScreen, Inventory, Cutscene, Paused, Evolution, Shop, Fishing }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    [SerializeField] PartyScreen partyScreen;
    [SerializeField] InventoryUI inventoryUI;

    [SerializeField] Beastiery beastieryUI;

    [SerializeField] BuddyController buddy;

    [SerializeField] GameObject cutscenes;
    public StateMachine<GameController> StateMachine { get; private set; }

    [SerializeField] AudioManager audioManager;

    public AudioManager GetAudioManager { get => audioManager; }

    public static GameController Instance { get; private set; }

    public BuddyController Buddy { get => buddy; } //set => buddy = value; }

    public PlayerController PlayerController { get => playerController; } //set => playerController = value; }

    GameState state;

    GameState prevState;



    private void Awake()
    {
        

        Instance = this;

        PlayerController.SetBuddy(Buddy);

        //SceneSystem.init();
        CreatureDB.init();
        MoveDB.init();
        ConditionDB.Init();
        ItemDB.init();
        QuestDB.init();
       
    }

    
    private void Start()
    {
        StateMachine = new StateMachine<GameController>(this);
      
        StateMachine.ChangeState(FreeRoamState.i);

        battleSystem.OnBattleOver += EndBattle;



        partyScreen.Init();

        DialogueManager.Instance.OnShowDialogue += () =>
        {
           StateMachine.Push(DialogueState.i);
            prevState = state;
        };

        DialogueManager.Instance.OnCloseDialogue += () =>
        {
            StateMachine.Pop();
            
        };

    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            StateMachine.Push(PauseState.i);
        }
        else
        {
            //prevState = state;
             StateMachine.Pop();
        }
    }

    public void StartBattle(BattleTrigger trigger)
    {
      BattleStates.i.trigger= trigger;
        StateMachine.Push(BattleStates.i);
    }

    TrainerController trainer;
    public void StartTrainerBattle(TrainerController trainer)
    {
        BattleStates.i.trainer = trainer;
        StateMachine.Push(BattleStates.i);

    }

    public void OnEnterTrainersView(TrainerController trainer)
    {

        StartCoroutine(trainer.TriggerTrainerBattles(playerController));
    }

    void EndBattle(bool won)
    {
        if (trainer != null && won == true)
        {
            trainer.BattleLost();
            trainer = null;
        }

        partyScreen.SetPartyData();
        UnityEngine.Debug.Log("is state");
        state = GameState.FreeRoam;

        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);

        //var playerParty = playerController.creatureparty;
        //bool hasEvolutions = playerParty.CheckForEvolutions();

       
    }


    private void Update()
    {
        StateMachine.Execute();

       

    }

   private void OnGUI()
   {
      //var style = new GUIStyle();
      //style.fontSize = 24;

      // GUILayout.Label("State Stack", style);

     // foreach(var state in StateMachine.StateStack)
    // {
    //    GUILayout.Label(state.GetType().ToString(), style);
  //     }
   }

    public IEnumerator MoveCamera(Vector2 moveOffset, bool waitForFadeOut = false)
    {
        yield return Fader.i.FadeIn(0.5f);

        worldCamera.transform.position += new Vector3(moveOffset.x, moveOffset.y);

        if (waitForFadeOut)
            yield return Fader.i.FadeOut(0.5f);
        else
            StartCoroutine(Fader.i.FadeOut(0.5f));
    }

    public void RevertToPrevState()
    {
        state = prevState;
    }

    public void startCutsceneState()
    {
        state = GameState.Cutscene;
    }


    public PlayerController Playercontroller => playerController;

    public Camera WorldCamera => worldCamera;
  
  
}
