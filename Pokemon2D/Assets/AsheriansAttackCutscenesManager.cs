using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsheriansAttackCutscenesManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    public Fader fader;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;


    public GameObject playerCam, battlecam, cutsceneCam2, cutsceneCam1;

    public GameObject blocker;

    public GameObject player;

    public GameObject buddy;

    public GameObject rescueMission;

    public Transform afterScenePos;

    // Start is called before the first frame update
    void Start()
    {
        battlesystem = FindObjectOfType<BattleSystem>();

        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();


        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[20].gameObject;

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;

        cutsceneCam1 = FindObjectOfType<cutsceneManagerr>().gameObject.transform.GetChild(23).gameObject.transform.GetChild(2).gameObject;

        cutsceneCam2 = FindObjectOfType<cutsceneManagerr>().gameObject.transform.GetChild(23).gameObject.transform.GetChild(3).gameObject;



    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.Count <= 0)

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
        thePlayer.blocker.SetActive(true);
        yield return new WaitForSeconds(.2f);
        player.SetActive(false);
        buddy.SetActive(false);
        battlecam.SetActive(false);
        triggerCutscene.SetActive(true);
        cutsceneCam1.SetActive(true);
        cutsceneCam2.SetActive(false);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(25f);
        yield return fader.FadeIn(2f);
        cutsceneCam1.SetActive(false);
        cutsceneCam2.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(32f);
        yield return fader.FadeIn(2f);
        cutsceneCam2.SetActive(false);
        player.transform.position = afterScenePos.position;
        buddy.transform.position = afterScenePos.position;
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        playerCam.SetActive(true);
        rescueMission.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);


        this.gameObject.SetActive(false);
    }
}
