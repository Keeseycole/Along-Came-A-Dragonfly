using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishboneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;

    PlayerController thePlayer;

    public Fader fader;
    public FadeToRed fadeRed;
    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject player;

    public GameObject buddy;

    
    



    // Start is called before the first frame update
    void Start()
    {


        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();

        fadeRed = FindObjectOfType<FadeToRed>();

        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[74].gameObject;




    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.hasFishBones1 == true && thePlayer.hasFishBones2 == true && thePlayer.hasFishBones3 == true
            && thePlayer.hasFishBones4 == true && thePlayer.hasFishBones5 == true 
            && thePlayer.hasFishBones6 == true)
        {
            trigger[0].SetActive(true);
        }


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
        yield return new WaitForSeconds(50f);
        yield return fader.FadeIn(2f);
        yield return fadeRed.FadeIn(.2f);
        yield return fadeRed.FadeOut(.2f);
        yield return new WaitForSeconds(4f);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        //npc.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
