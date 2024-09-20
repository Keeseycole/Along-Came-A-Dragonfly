using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilderFightCutsceneManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> Trigger;

    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject soilderFightCutscene;


    public bool hasarrived;

    public GameObject player;
    public GameObject buddy;
 
    PlayerController thePlayer;

    public Transform  spawnPoint;


    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        soilderFightCutscene = cutscenes.cutscenes[5].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();


        playerCam = thePlayer.transform.GetChild(1).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Trigger.Count <= 0)
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
        soilderFightCutscene.SetActive(true);
        
        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(24f);
        yield return fader.FadeIn(2f);
        soilderFightCutscene.SetActive(false);
    
        player.transform.position = spawnPoint.position;
        buddy.transform.position = spawnPoint.position;
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);
      

    }
}
