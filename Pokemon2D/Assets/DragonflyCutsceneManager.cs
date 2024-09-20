using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyCutsceneManager : TRiggerableEvent
{
    public List<GameObject> dragonflyTrigger;

 

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;


    public GameObject player;
    public GameObject buddy;

    public GameObject dragonfly, pebble, boulderFallTrigger;

    PlayerController thePlayer;


    cutsceneManagerr cutscenes;


    DragonflyCutsceneManager dragonflyCutsceneManager;

    // Start is called before the first frame update
    void Start()
    {

        dragonflyCutsceneManager = FindObjectOfType<DragonflyCutsceneManager>();

        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[10].gameObject;

        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();



        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (dragonflyTrigger.Count <= 0)
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

        player.SetActive(false);
        buddy.SetActive(false);
        yield return new WaitForSeconds(.2f);
    
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(1f);
        yield return new WaitForSeconds(12f);
        yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        triggerCutscene.SetActive(false);
        
    
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(1f);
        dragonfly.SetActive(true);
        pebble.SetActive(true);
        boulderFallTrigger.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
