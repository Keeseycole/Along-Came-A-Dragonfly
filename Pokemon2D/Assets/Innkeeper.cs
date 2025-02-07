using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innkeeper : MonoBehaviour, Interactable
{

    public Wallet wallet;


    public PlayerController player;


    public GameObject Sleeptriggers;

    public bool hasPayed;

    public GameObject innkeeperAfterPay;


    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        wallet= FindObjectOfType<Wallet>();
    }
    public IEnumerator Interact(Transform initer)
    {

        var animator = initer.GetComponent<CharecterAnimator>();




        int selectedChoice = 0;
       
        yield return DialogueManager.Instance.ShowDialogText($"oh, um, are you staying the night? its 100g",
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: (selection) => selectedChoice = selection);

      

        if (selectedChoice == 0)
        {
            //Yes

            hasPayed = true;

            yield return DialogueManager.Instance.ShowDialogText($"Thanks!");


            Wallet.i.TakeMoney(100);

            Sleeptriggers.SetActive(true);

            innkeeperAfterPay.SetActive(true);

            this.gameObject.SetActive(false);

        } else
        {
            hasPayed = false;
        }

        
    }
}

