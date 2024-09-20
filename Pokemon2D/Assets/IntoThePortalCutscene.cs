using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoThePortalCutscene : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> trigger;


    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject intoThePortalCutscene;


    public GameObject player;
    public GameObject buddy;
    PlayerController thePlayer;

    public Transform  spawnPoint;


    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    IntoThePortalCutscene intoThePotral;


    // Start is called before the first frame update
    void Start()
    {

        intoThePotral = FindObjectOfType<IntoThePortalCutscene>();
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        intoThePortalCutscene = cutscenes.cutscenes[31].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        spawnPoint = intoThePotral.gameObject.transform.GetChild(1);


        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;
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
        yield return fader.FadeIn(2f);
        intoThePortalCutscene.SetActive(true);
        player.SetActive(false);
        buddy.SetActive(false);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(10.5f);
        yield return fader.FadeIn(2f);
        intoThePortalCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        player.transform.position = spawnPoint.position;
        buddy.transform.position = spawnPoint.position;
        yield return fader.FadeOut(2f);
        functionCalled = false;
        this.gameObject.SetActive(false);
    }
}
