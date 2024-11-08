using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class OpeningCutsceneManager : TRiggerableEvent
{

    Cutscenes Thecutscene;

   

    public List<GameObject> OpeningCutsceneTrigger;

    public List<GameObject> objToSpawn;

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject playerCam, battlecam;

    public GameObject blocker;

    public GameObject player;
    public GameObject buddy;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    public Transform spawnPoint;

    OpeningCutsceneManager openingCutcene;



    // Start is called before the first frame update
    void Start()
    {

        
     

        openingCutcene = FindObjectOfType<OpeningCutsceneManager>();

        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[12].gameObject;

        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        playerCam = thePlayer.transform.GetChild(0).gameObject;

        battlecam = battlesystem.transform.GetChild(0).gameObject;

        blocker = thePlayer.transform.GetChild(1).gameObject;

  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpeningCutsceneTrigger.Count <= 0)
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

        Debug.Log("Mute");
      AudioManager.i.MuteMusic();

        thePlayer.blocker.SetActive(true);
        yield return fader.FadeIn(2f);
        player.SetActive(false);
        buddy.SetActive(false);
        objToSpawn[0].SetActive(false);
        triggerCutscene.SetActive(true);


        yield return new WaitForSeconds(8f);
       

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(85f);
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(22f);
        objToSpawn[1].SetActive(false);
        player.SetActive(true);
        thePlayer.blocker.SetActive(false);
        buddy.SetActive(true);
        player.transform.position = spawnPoint.position;
        buddy.transform.position = spawnPoint.position;


        triggerCutscene.SetActive(false);
       
        yield return fader.FadeOut(2f);





        AudioManager.i.UnMute();
        this.gameObject.SetActive(false);

    }
}
