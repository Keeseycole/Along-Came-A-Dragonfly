using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveInPastCutscene : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> trigger;


    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject arriveInPastCutscene;


    public GameObject player;
    public GameObject buddy;
    PlayerController thePlayer;

    public Transform arrivalPoint,spawnPoint;


    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        arriveInPastCutscene = cutscenes.cutscenes[4].gameObject;
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
        yield return fader.FadeIn(1f);
        player.SetActive(false);
        buddy.SetActive(false);
      
        //yield return new WaitForSeconds(.2f);
        arriveInPastCutscene.SetActive(true);
     
        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(13f);
        yield return fader.FadeIn(2f);
        arriveInPastCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);
        
  
        functionCalled = false;
        this.gameObject.SetActive(false);
    }
}
