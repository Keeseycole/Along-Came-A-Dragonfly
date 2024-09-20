using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarciusRescueCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    public Fader fader;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;


    public GameObject playerCam, battlecam;

    public GameObject blocker;

    public GameObject player;

    public GameObject buddy;


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

        triggerCutscene = cutscene.cutscenes[18].gameObject;

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;

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
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(22f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);

        this.gameObject.SetActive(false);
    }
}
