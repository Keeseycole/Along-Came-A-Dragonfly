using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishingTrigger : MonoBehaviour, Interactable, IPlayerTriggerable
{
    bool isfishing = false;

    public bool triggerRepeatedly => true;

   public GameObject fishingUI;

    GameController gc;

    public event Action OnFish;

    PlayerController player;

    CharecterAnimator charecterAnim;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();

        fishingUI = GameObject.Find("Fishing Parent").gameObject;

      player = FindObjectOfType<PlayerController>();

        charecterAnim = FindObjectOfType<CharecterAnimator>();
    }
    public IEnumerator Interact(Transform initer)
    {
        //isfishing = true;

        var animator = initer.GetComponent<CharecterAnimator>();
        //if (animator.IsSwimming || isfishing)
          //  yield break;

        yield return DialogueManager.Instance.ShowDialogText(" It looks like you can fish here.");
    

        int selectedChoice = 0;
        Debug.Log(" Fishing trigger game Dialogue Manager Instance", DialogueManager.Instance.gameObject);
        yield return DialogueManager.Instance.ShowDialogText($"Do you want to fish?",
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: (selection) => selectedChoice = selection);
      
       // GameController.Instance.StateMachine.Pop();


        if (selectedChoice == 0)
            {
            //Yes

          
            gc.StateMachine.Push(FishingState.i);
         
            fishingUI.transform.GetChild(0).gameObject.SetActive(true);
            player.ignoreInput = true;

            animator.IsFishing = true;


            //GameController.Instance.StateMachine.Pop();
           // isfishing = false;

        } 

    }

    public void OnCompanionTriggered(CompanionController companion)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerTriggered(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

     IEnumerator PlayerCatchFish(ItemBase fish, Transform initer)
    {
        var animator = initer.GetComponent<CharecterAnimator>();

        yield return DialogueManager.Instance.ShowDialogText($"You caught a {fish.name}");
        animator.IsFishing = false;
        gc.StateMachine.Pop();
    }

    public void CaughtFish (ItemBase fish, Transform initer)
    {
        StartCoroutine(PlayerCatchFish(fish, initer));
    }
}


