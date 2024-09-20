using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderDefenceSystemCutscene : TRiggerableEvent
{

   public  List<GameObject> triggers;


    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject playerCam, battlecam;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    public GameObject player;
    public GameObject buddy;


    private void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[6].gameObject;

        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        playerCam = thePlayer.transform.GetChild(1).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
    }

    void Update()
    {
        if (triggers.Count <= 0)
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

        player.SetActive(false);
        buddy.SetActive(false);
        //yield return new WaitForSeconds(.2f);
        triggerCutscene.SetActive(true);

        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(9f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);

        
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);

    }
}
