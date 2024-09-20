using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachTownFirstMeetingCutsceneManager :  TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    PlayerController thePlayer;

    public Fader fader;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject player;

    public GameObject buddy;

   public  GameObject waterkey;




    // Start is called before the first frame update
    void Start()
    {

      
        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();

        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[65].gameObject;




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


        triggerCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(28f);
        yield return fader.FadeIn(2f);
        waterkey.SetActive(true);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
