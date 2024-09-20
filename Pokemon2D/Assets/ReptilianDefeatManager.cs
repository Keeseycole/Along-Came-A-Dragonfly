using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianDefeatManager : MonoBehaviour
{
    public Fader fader;

    public WhiteFader whitefader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    public GameObject cam2;

    public GameObject ophinus;


 [SerializeField] public GameObject reptilianDefeatCutscene;



    public GameObject player;
    public GameObject buddy;

    public GameObject reptelian;

    PlayerController thePlayer;

    public Transform spawnPoint;


    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        reptilianDefeatCutscene = cutscenes.cutscenes[29].gameObject;
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
        if (enemies.Count <= 0)
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

        yield return fader.FadeIn(1f);

        player.SetActive(false);
        buddy.SetActive(false);
        //yield return new WaitForSeconds(.2f);
        reptilianDefeatCutscene.SetActive(true);
        battlecam.SetActive(false);
        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(3.7f);
        yield return fader.FadeIn(2f);
        ophinus.SetActive(true);
        yield return fader.FadeOut(2f);

        yield return new WaitForSeconds(17f);
        yield return  whitefader.FadeIn(2f);
        //reptilianDefeatCutscene.SetActive(false);
       // player.transform.position = spawnPoint.position;
       // buddy.transform.position = spawnPoint.position;
        cam2.SetActive(true);
        yield return whitefader.FadeOut(2f);
        

        this.gameObject.SetActive(false);
    }


}
