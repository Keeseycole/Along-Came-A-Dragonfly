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

    private void Start()
    {
        gc = FindObjectOfType<GameController>();

        fishingUI = GameObject.Find("Fishing Parent").gameObject;

      player = FindObjectOfType<PlayerController>();
    }
    public IEnumerator Interact(Transform initer)
    {
        //isfishing = true;

        var animator = initer.GetComponent<CharecterAnimator>();
        if (animator.IsSurfing || isfishing)
            yield break;

        yield return DialogueManager.Instance.ShowDialogText(" It looks like you can fish here.");
    

        int selectedChoice = 0;

        yield return DialogueManager.Instance.ShowDialogText($"Do you want to fish?",
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: (selection) => selectedChoice = selection);
      
       // GameController.Instance.StateMachine.Pop();


        if (selectedChoice == 0)
            {
            //Yes

          
            gc.StateMachine.Push(FishingState.i);
         
            fishingUI.transform.GetChild(0).gameObject.SetActive(true);
            player.blocker.SetActive(true);
            isfishing = true;
               
                animator.IsFishing = true;


            GameController.Instance.StateMachine.Pop();
            isfishing = false;

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
}


