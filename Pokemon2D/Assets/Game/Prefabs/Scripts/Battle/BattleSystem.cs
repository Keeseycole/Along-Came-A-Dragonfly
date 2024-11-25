using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Utils.StateMachine;

public enum BattleState
{
    Start,
    ActionSelection,
    MoveSelection,
    RunningTurn,
    Busy,
    PartyScreen,
    BattleOver,
    Inventory,
    ThrowCapsule
}
public enum BattleAction
{
    Move,
    SwitchCreature,
    UseItem,
    Flee,
    Storage

}

public enum BattleTrigger { Grasslands, Water, Snow }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] Battleunit playerUnit;
    [SerializeField] Battleunit enemyUnit;
    [SerializeField] BattleDialogueBox dialogueBox;
    [SerializeField] PartyScreen partyScreen;
    [SerializeField] GameObject captureCapsuleSprite;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] RunTurnState runTurns;
    GameController gc;
    [Tooltip("defult attack")]

    public GameObject battleUI;
    public GameObject battleCamera;
 
    [SerializeField] Image battleBackround;
    [SerializeField] Sprite grassBackround, waterBackround;

    [SerializeField]  public Button[] battleButtons;
    

    BattleState state;
    int currentAction;
    int currentMove;
   public int EscapeAttempts { get; set; }

    public event Action<bool> OnBattleOver;

    public int SelectedMove { get;  set; }

    public BattleAction SelectedAction { get; set; }

    public bool isBattleOver { get; private set; }

    public BattleDialogueBox battleDialogueBox { get { return dialogueBox; } }

   public Party playerParty { get; private set; }
   public Party trainerParty { get; private set; }
    public Creature PotentialCreature { get; private set; }

    public Creature SelectedCreature { get;  set; }

    public ItemBase SelectedItem { get; set; }


    public bool IsTrainerBattle { get; private set;} = false;

    PlayerController player;
    TrainerController trainer;

    public StateMachine<BattleSystem> StateMachine { get; private set; }


    public DamageNumber theDamageNumber;

    Wallet wallet;

    float moneyToAdd;


    BattleTrigger battletrigger;
    // Start is called before the first frame update

    [HideInInspector]
   public BattleSystem instance;
    private readonly BattleAction playerAction;

    private void Awake()
    {
        float moneyToAdd = UnityEngine.Random.Range(20, 100);
        wallet = FindObjectOfType<Wallet>();
        instance = this;
       
    }

    private void Start()
    {
        playerParty = FindObjectOfType<Party>();
        RunTurnState.i.Enter(this);
        ButtonInit();
    }

 
    public void StartBattle(Party playerParty, Creature potentialCreature, BattleTrigger trigger = BattleTrigger.Grasslands)
    {
        this.playerParty = playerParty;
        this.PotentialCreature = potentialCreature;
        player = playerParty.GetComponent<PlayerController>();
        IsTrainerBattle = false;
        battletrigger = trigger;

        StartCoroutine(SetUpBattle());
    }

    public void StartBattle(Party playerParty, Party trainerParty, BattleTrigger trigger = BattleTrigger.Grasslands)
    {
        
        this.playerParty = playerParty;
        this.trainerParty = trainerParty;

        IsTrainerBattle = true;

        player = playerParty.GetComponent<PlayerController>();
        trainer = trainerParty.GetComponent<TrainerController>();

        battletrigger = trigger;
        StartCoroutine(SetUpBattle());
    }

    public void HandleUpdate()
    {
        StateMachine.Execute();
     
           
    }

    public void BattleOver(bool won)
    {
        isBattleOver = true;
        playerParty.Creatures.ForEach(p => p.OnBattleOver());
        playerUnit.Hud.ClearData();
        enemyUnit.Hud.ClearData();
        OnBattleOver(won);
    }

   public IEnumerator SwitchCreature(Creature Newcreature)
    {
        if (playerUnit.Creature.HP > 0)
        {

            playerUnit.PlayDeathAnim();
            yield return new WaitForSeconds(1f);
        }
        playerUnit.SetUp(Newcreature);
        dialogueBox.UpdateMoveList(Newcreature.Moves);

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator SetUpBattle()
    {
        battleUI.SetActive(true);
        battleCamera.SetActive(true);
        StateMachine = new StateMachine<BattleSystem>(this);

        playerUnit.Clear();
        enemyUnit.Clear();

        //  battleBackround.sprite = (battletrigger == BattleTrigger.Grasslands) ? grassBackround : waterBackround;

        battleBackround.sprite = SceneSystem.currentLevelManager.GetBackround;

        if (!IsTrainerBattle)
        {
          
            enemyUnit.SetUp(PotentialCreature);     
        }
        else
        {
            // send enemy creature
            enemyUnit.gameObject.SetActive(true);
            var enemyCreature = trainerParty.GetUninjuredCreature();
            enemyUnit.SetUp(enemyCreature);

            // send player creature
            playerUnit.gameObject.SetActive(true);
          
        }
        playerUnit.SetUp(playerParty.GetUninjuredCreature());
        dialogueBox.UpdateMoveList(playerUnit.Creature.Moves);


        isBattleOver = false;
        EscapeAttempts = 0;
        partyScreen.Init();
        yield return new WaitForSeconds(.1f);

        //Debug.Log(atkButton.gameObject);
        ActionSelection();
        

    }



  public void ActionSelection()
    {
        dialogueBox.EnableActionSelector(true);
        dialogueBox.DisableMoveSelector(); 
        EventSystem.current.SetSelectedGameObject(battleButtons[0].gameObject);
       
    }
  

    public bool CheckMoveMP(Battleunit sourceUnit, Move moveToCheck)
    {

        if (sourceUnit.Creature.MP >= moveToCheck.MPCost)
        {     
            sourceUnit.Creature.MP -= moveToCheck.MPCost;
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool CheckMoveMP(Move moveToCheck)
    {

        if (playerUnit.Creature.MP >= moveToCheck.MPCost)
        {
            playerUnit.Creature.MP -= moveToCheck.MPCost;
            return true;
        }

        else
        {
            return false;
        }
    }



    IEnumerator SendNextTrainerCreature(Creature nextCreature)
    {
        state = BattleState.Busy;

        enemyUnit.SetUp(nextCreature);
        yield return new WaitForSeconds(1f);
        state = BattleState.RunningTurn;
    }

    IEnumerator OnItemUsed(ItemBase usedItem)
    {
        
        inventoryUI.gameObject.SetActive(false);

        if (usedItem is CapsuleItem)
        {
            yield return ThrowCapsule((CapsuleItem)usedItem);
        }

       //  StartCoroutine(RunTurnState(runTurns));
    }
    public IEnumerator ThrowCapsule(CapsuleItem capsuleItem)
    {

        if(IsTrainerBattle)
        {
           
            state = BattleState.RunningTurn;
            yield return DialogueManager.Instance.ShowDialogText("cant capture.");
            yield break;
        }
        
        state = BattleState.ThrowCapsule;
        yield return new WaitForSeconds(1f);
        var capsuleObj =  Instantiate(captureCapsuleSprite, playerUnit.transform.position - new Vector3(2, 0), Quaternion.identity);
        var capsule = capsuleObj.GetComponent<SpriteRenderer>();
        capsule.sprite = capsuleItem.Icon;

        //animations
        yield return capsule.transform.DOJump(enemyUnit.transform.position + new Vector3(0, 2), 2f, 1, 1f).WaitForCompletion();

        yield return enemyUnit.PlayCaptureAnimation();
        capsule.transform.DOMoveY(enemyUnit.transform.position.y - 1.3f, .5f).WaitForCompletion();

        int shakeCount = TryToCatchCreature(enemyUnit.Creature, capsuleItem);

        for (int i = 0; i < shakeCount; ++i)
        {
            yield return new WaitForSeconds(.5f);
           yield return capsule.transform.DOPunchRotation(new Vector3(0, 0, 10f), .8f).WaitForCompletion();
        }
        if(shakeCount == 4)
        {
            yield return capsule.DOFade(0, 1.5f).WaitForCompletion();
            yield return DialogueManager.Instance.ShowDialogText("creature has been added to your party");
            playerParty.AddCreature(enemyUnit.Creature);

            Destroy(capsule);
            BattleOver(true);
            yield break;
        }
        yield return new WaitForSeconds(1f);
        capsule.DOFade(0, 0.2f);
        yield return enemyUnit.PlayBreakOutAnimation();

        Destroy(capsule);
        StartCoroutine(RunTurnState.i.RunTurns(BattleAction.UseItem, 0));
    }

 

    int TryToCatchCreature(Creature creature, CapsuleItem capsuleItem)
    {
        float a = (3 * creature.MaxHP - 2 * creature.HP) * creature.Base.CatchRate * capsuleItem.CatchRateMod
        * ConditionDB.GetStatusBounus(creature.Status) / (3 * creature.MaxHP);

        if (a >= 255)
            return 4;

        float b = 1048560 / MathF.Sqrt(MathF.Sqrt(16711680 / a));

        int shakeCount = 0;

        while(shakeCount < 4)
        {
            if (UnityEngine.Random.Range(0, 65535) >= b)
              break;

            ++shakeCount;
        }

        return shakeCount;
    }

    void ButtonInit()
    {
        Enter();

        battleButtons[0].onClick.AddListener(() =>
        {
           
            StartCoroutine(RunTurnState.i.RunTurns(BattleAction.Move, 0));
            dialogueBox.EnableActionSelector(false);
        });

        battleButtons[1].onClick.AddListener(() => {
            dialogueBox.UpdateMP(playerUnit.Creature);

            SelectedAction = BattleAction.Move;
            StateMachine.ChangeState(MoveSelectionState.i);
            dialogueBox.Enter();
        });

        battleButtons[2].onClick.AddListener(() => 
        {
            Debug.Log("item clicked");
            StartCoroutine(GoToInventoryState());
         
      //      Action<ItemBase> onItemUsed = (ItemBase usedItem) =>
         //   {
          //      StartCoroutine(OnItemUsed(usedItem));
           // };
        });

        battleButtons[3].onClick.AddListener(() => {

            Debug.Log("Party clicked");
            StartCoroutine(GoToPartyState());
          
        });

        battleButtons[4].onClick.AddListener(() =>
        {
           SelectedAction = BattleAction.Flee;
            StateMachine.ChangeState(RunTurnState.i);

        });


        battleButtons[5].onClick.AddListener(() =>
        {
            SelectedAction = BattleAction.Storage;
            StateMachine.ChangeState(StorageState.i);

        });


    }

   public IEnumerator GoToInventoryState()
    {
        yield return GameController.Instance.StateMachine.PushandWait(InventoryState.i);
        var selectedItem = InventoryState.i.selectedItem;
        if (selectedItem != null)
        {
            SelectedAction = BattleAction.UseItem;
            SelectedItem = selectedItem;
            StateMachine.ChangeState(RunTurnState.i);
        }
    }

    void HandlePartySelection()
    {
        Action onSelected = () =>
        {
            var selectedcreature = partyScreen.SelectedCreature;

            if (selectedcreature.HP <= 0)
            {
                return;
            }
            if (selectedcreature == PlayerUnit.Creature)
            {
                return;
            }
        };

    }

    public IEnumerator GoToPartyState()
    {
        yield return GameController.Instance.StateMachine.PushandWait(GamePartyStates.i);
        var selectedCreature = GamePartyStates.i.SelectedCreature;

        if (selectedCreature != null)
        {
            SelectedAction = BattleAction.SwitchCreature;
            SelectedCreature = selectedCreature;
         StateMachine.ChangeState(RunTurnState.i);
        }
    }

    public void Enter(int currentButton = 0)
    {

        EventSystem.current.SetSelectedGameObject(battleButtons[currentButton].gameObject);
    }



    public Battleunit PlayerUnit => playerUnit;

    public Battleunit EnemyUnit => enemyUnit;

    public PartyScreen PartyScreen => partyScreen;

    //public BattleDialogueBox BattleDialogueBox => battleDialogueBox;

}

