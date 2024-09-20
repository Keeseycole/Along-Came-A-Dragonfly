using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphinusCrystelCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;


    public GameObject camera2;

    public Fader fader;

    PlayerController thePlayer;

    BuddyController theBuddy;

    BattleSystem battlesystem;

    public GameObject player, buddy;

    public GameObject spawnpoint;

    public GameObject kingJastus;

    public GameObject portal;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;

    [SerializeField] public GameObject NextCutsceneTrigger;

    OphinusCrystelCutsceneManager takeCrystel;

     

    // Start is called before the first frame update
    void Start()
    {
       
        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        theBuddy = FindObjectOfType<BuddyController>();

        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();


     //   camera2 = cutscene.gameObject.transform.GetChild(3).gameObject.transform.GetChild(7).gameObject;


        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[27].gameObject;

        takeCrystel = FindObjectOfType<OphinusCrystelCutsceneManager>();

        kingJastus = takeCrystel.gameObject.transform.GetChild(1).gameObject;


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
        thePlayer.blocker.SetActive(true);
        yield return new WaitForSeconds(.2f);
        player.SetActive(false);
        buddy.SetActive(false);
        triggerCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        // ophinusHouse.SetActive(false);
        yield return new WaitForSeconds(132.5f);
        yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(22f);
        yield return fader.FadeIn(2f);
        camera2.SetActive(true);
        yield return fader.FadeOut(2f);

        yield return new WaitForSeconds(73f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        player.transform.position = spawnpoint.transform.position;
        buddy.transform.position = spawnpoint.transform.position;
        player.SetActive(true);
        thePlayer.blocker.SetActive(false);
        buddy.SetActive(true);
        kingJastus.SetActive(true);
        portal.SetActive(true);
        NextCutsceneTrigger.SetActive(true);
        yield return fader.FadeOut(2f);
        this.gameObject.SetActive(false);
    }
}
