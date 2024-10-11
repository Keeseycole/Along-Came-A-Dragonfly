using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetOphinusCutsceneManager : TRiggerableEvent
{
  

   public  List<GameObject> meetOphinusTrigger;

   public bool functionCalled = false;

   public Fader fader;

   [SerializeField] public GameObject triggerCutscene;

   [SerializeField] public Transform spawnArea;

    public GameObject playerCam, battlecam;

    PlayerController thePlayer;

    public GameObject player;
    public GameObject buddy;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    private void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[7].gameObject;

        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;

        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

       
    }

    void Update()
    {
        if (meetOphinusTrigger.Count <= 0)
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
        thePlayer.ignoreInput = true;
        yield return new WaitForSeconds(.2f);
        playerCam.SetActive(false);
        battlecam.SetActive(false);
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(28f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        player.transform.position = spawnArea.position;
        buddy.transform.position = spawnArea.position;
        playerCam.SetActive(true);
        yield return new WaitForSeconds(.1f);
        yield return fader.FadeOut(2f);
        thePlayer.ignoreInput = false;
        this.gameObject.SetActive(false);
    }
}
