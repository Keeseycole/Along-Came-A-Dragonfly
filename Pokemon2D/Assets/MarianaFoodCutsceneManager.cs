using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarianaFoodCutsceneManager : TRiggerableEvent
{
    public List<GameObject> marianaFoodTrigger;

    public List<GameObject> objToSpawn;

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject playerCam, battlecam;

    public GameObject blocker;


    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    public GameObject player;
    public GameObject buddy;
    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[8].gameObject;

        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

     player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (marianaFoodTrigger.Count <= 0)
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

        objToSpawn[0].SetActive(false);
        objToSpawn[1].SetActive(false);
        objToSpawn[2].SetActive(false);
        objToSpawn[3].SetActive(false);

       

        yield return new WaitForSeconds(.2f);

        player.SetActive(false);
        buddy.SetActive(false);
        triggerCutscene.SetActive(true);
        marianaFoodTrigger[0].SetActive(false);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(57f);
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(1f);
        triggerCutscene.SetActive(false);
        objToSpawn[0].SetActive(true);
        objToSpawn[1].SetActive(true);
        objToSpawn[2].SetActive(true);
        objToSpawn[3].SetActive(true);
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);
       

        
      

    }
}
