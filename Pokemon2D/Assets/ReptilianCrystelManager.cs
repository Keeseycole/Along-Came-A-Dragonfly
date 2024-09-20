using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianCrystelManager : MonoBehaviour
{
    public Fader fader;

    public List<GameObject> trigger;

    public bool functionCalled = false;

    public GameObject playerCam, battlecam;

    [SerializeField] public GameObject reptilianCrystelCutscene;



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

        reptilianCrystelCutscene = cutscenes.cutscenes[28].gameObject;
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

        yield return fader.FadeIn(1f);

        player.SetActive(false);
        buddy.SetActive(false);
        //yield return new WaitForSeconds(.2f);
        reptilianCrystelCutscene.SetActive(true);
        battlecam.SetActive(false);
        yield return fader.FadeOut(1f);
        //yield return fader.FadeIn(1f);
        yield return new WaitForSeconds(15f);
        yield return fader.FadeIn(2f);
        reptilianCrystelCutscene.SetActive(false);
        battlecam.SetActive(true);
        player.SetActive(true);
        buddy.SetActive(true);
        reptelian.SetActive(true);
        player.transform.position = spawnPoint.position;
        buddy.transform.position = spawnPoint.position;
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);

        this.gameObject.SetActive(false);
    }


}
