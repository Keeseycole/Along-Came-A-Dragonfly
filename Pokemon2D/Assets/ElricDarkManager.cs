using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElricDarkManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    [SerializeField] public GameObject elricFoundBigKeyCutscene;

    public GameObject player;
    public GameObject buddy;

    PlayerController thePlayer;

    cutsceneManagerr cutscenes;

    ElricDarkManager elricDarkMan;

    public GameObject trigger;



    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        elricDarkMan = FindObjectOfType<ElricDarkManager>();

        enemies[0] = elricDarkMan.gameObject.transform.GetChild(0).gameObject;


        elricFoundBigKeyCutscene = cutscenes.cutscenes[55].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

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
        yield return new WaitForSeconds(16f);
        yield return fader.FadeIn(2f);

        elricFoundBigKeyCutscene.SetActive(false);

        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);


        this.gameObject.SetActive(false);
    }
}
