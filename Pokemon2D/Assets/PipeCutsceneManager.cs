using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCutsceneManager : TRiggerableEvent
{

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject PipeDoorCutscene;

    PipeEnemies pipeEnemies;

    public List<GameObject> enemies;

    public GameObject door;


    PlayerController thePlayer;

    BuddyController theBuddy;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        pipeEnemies= FindObjectOfType<PipeEnemies>();


        PipeDoorCutscene = cutscenes.cutscenes[64].gameObject;

        thePlayer = FindObjectOfType<PlayerController>();
        theBuddy= FindObjectOfType<BuddyController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

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
    
        yield return new WaitForSeconds(.2f);
        thePlayer.gameObject.SetActive(false);
        theBuddy.gameObject.SetActive(false);
        door.SetActive(false);
        PipeDoorCutscene.SetActive(true);
        yield return fader.FadeOut(4f);
        yield return fader.FadeIn(2f);
      
        PipeDoorCutscene.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theBuddy.gameObject.SetActive(true);
        yield return fader.FadeOut(2f);
      
        this.gameObject.SetActive(false);
    }
}
