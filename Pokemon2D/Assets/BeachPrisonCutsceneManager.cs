using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachPrisonCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public Fader fader;


    public List<GameObject> enemies;

    public GameObject player;

    public GameObject buddy;

    public GameObject rescueNPC;

    public GameObject prisonDoor;



    BattleSystem battlesystem;

    public Transform sailPoint;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;


    public GameObject playerCam, battlecam;

    public GameObject blocker;

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        battlesystem = FindObjectOfType<BattleSystem>();

        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        functionCalled = false;

        fader = FindObjectOfType<Fader>();


        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[17].gameObject;

      

    }
    // Update is called once per frame
    void Update()
    {
        if (enemies.Count <= 0)
        {
          
            if (!functionCalled)
            {
                
                functionCalled = true;
                prisonDoor.SetActive(false);
                StartCoroutine(PlayCutscene());

            }
        }
    }

  
    public override IEnumerator PlayCutscene()
    {
        yield return fader.FadeIn(1f);
        triggerCutscene.SetActive(true);
        yield return new WaitForSeconds(.2f);
        player.SetActive(false);
        buddy.SetActive(false);
     
        rescueNPC.SetActive(false);
        yield return fader.FadeOut(1f);
        yield return new WaitForSeconds(8f);
        yield return fader.FadeIn(2f);
        player.transform.position = sailPoint.transform.position;
        buddy.transform.position = sailPoint.transform.position;
      
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
      
        yield return fader.FadeOut(2f);
        trigger.SetActive(true);
    }
}
