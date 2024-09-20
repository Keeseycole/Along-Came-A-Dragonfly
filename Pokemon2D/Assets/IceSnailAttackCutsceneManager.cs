using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSnailAttackCutsceneManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> trigger;

    public bool functionCalled = false;

    public GameObject enemies;

    public GameObject iceSnail;

    [SerializeField] public GameObject IceSnailAttackedCutscene;



    public GameObject player;
    public GameObject buddy;



    PlayerController thePlayer;



    cutsceneManagerr cutscenes;

    IceSnailRescuedCutsceneManager iceSnailRescue;

    // Start is called before the first frame update
    void Start()
    {

        iceSnailRescue = FindObjectOfType<IceSnailRescuedCutsceneManager>();

        cutscenes = FindObjectOfType<cutsceneManagerr>();

        IceSnailAttackedCutscene = cutscenes.cutscenes[60].gameObject;

        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;
     
        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();

        enemies = iceSnailRescue.gameObject.transform.GetChild(1).gameObject;



    }

    private void Update()
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

        IceSnailAttackedCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(22f);
        yield return fader.FadeIn(2f);

        IceSnailAttackedCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        enemies.SetActive(true);
        iceSnail.SetActive(true);
        yield return fader.FadeOut(2f);

    }
}
