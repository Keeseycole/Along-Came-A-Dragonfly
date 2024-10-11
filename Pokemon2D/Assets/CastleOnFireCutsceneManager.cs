using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleOnFireCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    public GameObject theTrigger;

    public Fader fader;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    public GameObject player;

    public GameObject buddy;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;


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

        triggerCutscene = cutscene.cutscenes[24].gameObject;


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
        thePlayer.ignoreInput = true;
        yield return new WaitForSeconds(.2f);
        player.SetActive(false);

        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(4f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.ignoreInput = false;
        theTrigger.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
