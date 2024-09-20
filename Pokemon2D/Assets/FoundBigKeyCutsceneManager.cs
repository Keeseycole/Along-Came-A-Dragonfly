using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundBigKeyCutsceneManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    [SerializeField] public GameObject elricFoundBigKeyCutscene;

    public GameObject player;
    public GameObject buddy;

    PlayerController thePlayer;

    cutsceneManagerr cutscenes;

    FoundBigKeyCutsceneManager elricBigKey;

    ElricEscapePrisonCutscene elricEscapeMan;

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        elricEscapeMan = FindObjectOfType<ElricEscapePrisonCutscene>();

        elricFoundBigKeyCutscene = cutscenes.cutscenes[50].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        elricBigKey = FindObjectOfType<FoundBigKeyCutsceneManager>();

        enemies[0] = elricBigKey.gameObject.transform.GetChild(0).gameObject;

        trigger = elricEscapeMan.gameObject.transform.GetChild(0).gameObject;

    }

    private void Update()
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

        yield return new WaitForSeconds(.2f);
        player.SetActive(false);
        buddy.SetActive(false);

        elricFoundBigKeyCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);

        elricFoundBigKeyCutscene.SetActive(false);


        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
