using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCastleManager : Cutscenes
{
    public Fader fader;

    public WhiteFader whitefader;

    public List<GameObject> trigger;

    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    public GameObject faketiles;


    [SerializeField] public GameObject hiddenCastlecutscene;



    public GameObject player;
    public GameObject buddy;

  
    PlayerController thePlayer;


    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        hiddenCastlecutscene = cutscenes.cutscenes[30].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();
        whitefader = FindObjectOfType<WhiteFader>();

        playerCam = thePlayer.transform.GetChild(1).gameObject;

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

                StartCoroutine(soilderFightEvent());

            }
        }
    }

    public IEnumerator soilderFightEvent()
    {
        startCutscene();
        yield return fader.FadeIn(1f);

        player.SetActive(false);
        buddy.SetActive(false);
        //yield return new WaitForSeconds(.2f);
        hiddenCastlecutscene.SetActive(true);
        battlecam.SetActive(false);
        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(24.3f);
        yield return whitefader.FadeIn(2.2f);
        faketiles.SetActive(false);
        yield return whitefader.FadeOut(2f);
      
        yield return new WaitForSeconds(7f);

        yield return fader.FadeIn(2f);
        player.SetActive(true);
        buddy.SetActive(true);
        yield return new WaitForSeconds(2f);
        hiddenCastlecutscene.SetActive(false);
        yield return fader.FadeOut(2f);
        endCutscene();
        this.gameObject.SetActive(false);


    }


}
