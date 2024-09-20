using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEarthTurtleDefeatManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;



    [SerializeField] public GameObject EarthTurtleDefeatCutscene;



    public GameObject player;
    public GameObject buddy;



    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    FutureDefeatManager futureDefeatMan;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        EarthTurtleDefeatCutscene = cutscenes.cutscenes[43].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
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

        EarthTurtleDefeatCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(7f);
        yield return fader.FadeIn(2f);

        EarthTurtleDefeatCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }

}
