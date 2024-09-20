using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : TRiggerableEvent
{
    public List<GameObject> Wave1Enemies;

   

    public GameObject WavetoSpawn;

    public GameObject[]  shipstoSpawn;

    public GameObject  battlecam, enemiestoSpawn;

    public Fader fader;

    public GameObject playerCam;

    public GameObject blocker;


    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    [SerializeField] public GameObject triggerCutscene;

    public bool functionCalled = false;
    public float cutsceneTime, delaytime;

    public object CaptureState()
    {
        throw new NotImplementedException();
    }

    public void RestoreState(object state)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();
      
        fader = FindObjectOfType<Fader>();

        triggerCutscene = cutscenes.cutscenes[14].gameObject;

        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (Wave1Enemies.Count <= 0)
        {
            
            if (!functionCalled)
            {
               
                functionCalled = true;
                StartCoroutine(PlayCutscene());

                
            }
            
        }

       
    }

    

    public override IEnumerator PlayCutscene()
    {

        yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(.2f);
        battlecam.SetActive(false);
        playerCam.SetActive(false);
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);

        yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(.2f);
        triggerCutscene.SetActive(false);
        playerCam.SetActive(true);
        shipstoSpawn[0].SetActive(true);
        WavetoSpawn.SetActive(true);
        yield return fader.FadeOut(2f);
    }
}
