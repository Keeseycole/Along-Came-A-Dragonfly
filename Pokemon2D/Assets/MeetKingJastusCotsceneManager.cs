using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetKingJastusCotsceneManager : MonoBehaviour
{
    public List<GameObject> MeetKingJastusTrigger;

    public List<GameObject> objsToSpawn;
    //public List<GameObject> objToSpawn;

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject playerCam, battlecam;

    public GameObject blocker;


    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;
    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[9].gameObject;

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
        if (MeetKingJastusTrigger.Count <= 0)
        {

            if (!functionCalled)
            {

                functionCalled = true;
                StartCoroutine(TriggerCutscene());

            }
        }
    }

    public IEnumerator TriggerCutscene()
    {
        blocker.SetActive(true);
        yield return fader.FadeIn(1f);

        yield return new WaitForSeconds(.2f);
        playerCam.SetActive(false);
        battlecam.SetActive(false);
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(106f);
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(1f);
        triggerCutscene.SetActive(false);
        playerCam.SetActive(true);
        objsToSpawn[0].SetActive(true);
        yield return fader.FadeOut(2f);
        blocker.SetActive(false);
        this.gameObject.SetActive(false);

    }

}
