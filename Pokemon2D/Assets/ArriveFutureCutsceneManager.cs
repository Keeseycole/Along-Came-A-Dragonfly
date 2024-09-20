using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveFutureCutsceneManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> trigger;


    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject futureArriveCutscene;




    public GameObject player;
    public GameObject buddy;
    PlayerController thePlayer;



    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        futureArriveCutscene = cutscenes.cutscenes[34].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();


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
        player.SetActive(false);
        buddy.SetActive(false);
        futureArriveCutscene.SetActive(true);
        yield return fader.FadeOut(2f);

        yield return new WaitForSeconds(6.5f);
        yield return fader.FadeIn(2f);
        player.SetActive(true);
        buddy.SetActive(true);
        futureArriveCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);
        functionCalled = false;
        this.gameObject.SetActive(false);
    }
}
