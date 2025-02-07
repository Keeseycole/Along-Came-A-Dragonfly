using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PianoPlayer : MonoBehaviour, Interactable
{
    public LevelManager levelManager;

    public Wallet wallet;


    PlayerController player;

    AudioManager audioman;

    

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public IEnumerator Interact(Transform initer)
    {

        var animator = initer.GetComponent<CharecterAnimator>();




        int selectedChoice = 0;
        Debug.Log(" Fishing trigger game Dialogue Manager Instance", DialogueManager.Instance.gameObject);
        yield return DialogueManager.Instance.ShowDialogText($"Can you spare some money for some... juice?",
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: (selection) => selectedChoice = selection);

        // GameController.Instance.StateMachine.Pop();

        int ranSong = UnityEngine.Random.Range(0, audioman.musicList.Count);

        if (selectedChoice == 0)
        {
            //Yes

            yield return DialogueManager.Instance.ShowDialogText($"Thanks!");


            Wallet.i.TakeMoney(10);
            
            if(levelManager.musicToPlay == null) 
            
            {  
                levelManager.musicToPlay = audioman.musicList[ranSong];

                StartCoroutine(ChangSize());
            }

            if (levelManager.musicToPlay != null)

            {
                levelManager.musicToPlay = audioman.musicList[ranSong];

                StartCoroutine(ChangSize());
            }

        }
    }

    IEnumerator ChangSize()
    {
        levelManager.boxCollider.offset = new Vector2(.2f, -0.06f);
        levelManager.boxCollider.size = new Vector2(.08f, .1f);

        yield return new WaitForSeconds(.2f);


        levelManager.boxCollider.offset = new Vector2(.21f, -0.04f);
        levelManager.boxCollider.size = new Vector2(.0857f, .151f);

    }

    

}
