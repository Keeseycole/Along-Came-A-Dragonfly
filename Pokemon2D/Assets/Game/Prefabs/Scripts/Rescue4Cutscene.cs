using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue4Cutscene : TRiggerableEvent
{
    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject Rescue4cutscene;

    public GameObject playerCam, battlecam;

    public List<GameObject> enemies;

    public GameObject rescueNPC, rescueNPC2, rescueNPC3;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        Rescue4cutscene = cutscenes.cutscenes[3].gameObject;

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
        if (enemies.Count <= 0)
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
        rescueNPC.SetActive(false);
        rescueNPC2.SetActive(false);
        rescueNPC3.SetActive(false);
        Rescue4cutscene.SetActive(true);
        yield return fader.FadeOut(4f);
        yield return fader.FadeIn(2f);
        //yield return new WaitForSeconds(8f);
        Rescue4cutscene.SetActive(false);
        playerCam.SetActive(true);
        yield return fader.FadeOut(2f);
        thePlayer.blocker.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
