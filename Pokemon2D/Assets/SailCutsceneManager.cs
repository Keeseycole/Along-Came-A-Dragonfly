using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailCutsceneManager : TRiggerableEvent
{

    public bool functionCalled = false;

    public Fader fader;


    [SerializeField] public GameObject sailCutscene;

    public GameObject playerCam, battlecam;

    public List<GameObject> enemies;

   public GameObject player;
   public GameObject buddy;
   
    PlayerController thePlayer;

    BuddyController thebuddy;

    cutsceneManagerr cutscenes;

    SailCutsceneManager sailCutseneManager;

    BattleSystem battlesystem;

    public Transform sailPoint;

    public GameObject sailtoShip, sailBackship;

    public GameObject blocker;

    // Start is called before the first frame update
    void Start()
    {
        battlesystem = FindObjectOfType<BattleSystem>();

        thePlayer = FindObjectOfType<PlayerController>();

        thebuddy= FindObjectOfType<BuddyController>();
        
        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        cutscenes = FindObjectOfType<cutsceneManagerr>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();

        sailCutscene = cutscenes.cutscenes[16].gameObject;

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;

        sailCutseneManager = FindObjectOfType<SailCutsceneManager>();

        sailPoint = sailCutseneManager.transform.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
      if(enemies.Count <= 0) 
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
        thePlayer.blocker.SetActive(true);
        yield return new WaitForSeconds(.2f);
        playerCam.SetActive(false);
        battlecam.SetActive(false);
        sailCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(2f);

        yield return fader.FadeIn(1f);
        //sailtoShip.SetActive(false);
        //sailBackship.SetActive(true);
        player.transform.position = sailPoint.position;
        buddy.transform.position = sailPoint.position;
        yield return new WaitForSeconds(1f);
        sailCutscene.SetActive(false);
        playerCam.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);
    }
}
