using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherworldPotralCutscene : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> trigger;


   

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject otherworldPortal;


 

    public GameObject player;
    public GameObject buddy;
    PlayerController thePlayer;



    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        otherworldPortal = cutscenes.cutscenes[32].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
   
        fader = FindObjectOfType<Fader>();


        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;
    }
   
 

  
    public override IEnumerator PlayCutscene()
    {
        yield return fader.FadeIn(1f);
        thePlayer.blocker.SetActive(true);

        otherworldPortal.SetActive(true);
        battlecam.SetActive(false);
        playerCam.SetActive(false);
        yield return fader.FadeOut(1f);

        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);
        otherworldPortal.SetActive(false);
        battlecam.SetActive(true);
        playerCam.SetActive(true);
        thePlayer.blocker.SetActive(false);
        yield return fader.FadeOut(2f);
     
        this.gameObject.SetActive(false);
    }
}
