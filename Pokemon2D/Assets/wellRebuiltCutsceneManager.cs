using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellRebuiltCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    PlayerController thePlayer;

    WellPuzzleManager wellPuzzleManager;

    public Fader fader;

    cutsceneManagerr cutscene;


    [SerializeField] public GameObject triggerCutscene;


    public GameObject player;

    public GameObject buddy;

    public GameObject statue, emptystatue, pieces;

    public GameObject wellPieces;

    public GameObject cam2;

     wellRebuiltCutsceneManager wellrebuiltMan;


    // Start is called before the first frame update
    void Start()
    {

        wellrebuiltMan = FindObjectOfType<wellRebuiltCutsceneManager>();

        wellPuzzleManager = FindObjectOfType<WellPuzzleManager>();


        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();

        statue = wellPuzzleManager.transform.GetChild(2).gameObject;

        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[42].gameObject;

        emptystatue = wellPuzzleManager.transform.GetChild(4).gameObject;

        pieces = wellPuzzleManager.transform.GetChild(0).gameObject;

        wellPieces = wellPuzzleManager.transform.GetChild(3).gameObject;

        cam2 = wellrebuiltMan.transform.GetChild(0).gameObject;

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

        yield return new WaitForSeconds(.2f);
        player.SetActive(false);
        buddy.SetActive(false);

        emptystatue.SetActive(false);
        pieces.SetActive(false);
        triggerCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);
        cam2.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);

        player.SetActive(true);
        buddy.SetActive(true);
        wellPieces.SetActive(false);

        statue.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
