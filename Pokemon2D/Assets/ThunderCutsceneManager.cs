using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCutsceneManager : TRiggerableEvent
{
    public List<GameObject> Wave2Enemies;
    public GameObject enemiestoSpawn;


    public List<GameObject> trigger;


    BattleSystem battlesystem;

    public Fader fader;

    public GameObject thundertrigger;

    cutsceneManagerr cutscenes;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject cam2;

    public GameObject bridgeBlocker;

    public bool functionCalled = false;


    public GameObject player;

    public GameObject buddy;





    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;

        buddy = FindObjectOfType<BuddyController>().gameObject;

        cutscenes = FindObjectOfType<cutsceneManagerr>();

        functionCalled = false;

         fader= FindObjectOfType<Fader>();

        triggerCutscene = cutscenes.cutscenes[15].gameObject;

        cam2 = cutscenes.gameObject.transform.GetChild(6).gameObject.transform.GetChild(6).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(Wave2Enemies.Count <= 0)
        {
            StartCoroutine(CutsceneTrigger());
        }


        if (trigger.Count <= 0)
        {

            if (!functionCalled)
            {

                functionCalled = true;

                StartCoroutine(PlayCutscene());

            }

        }
     
    }



    IEnumerator CutsceneTrigger()
    {
        yield return new WaitForSeconds(1f);
        trigger[0].SetActive(true);
    }

    public override IEnumerator PlayCutscene()
    {
        yield return fader.FadeIn(1f);
       
        player.SetActive(false);
        buddy.SetActive(false);
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(4f);

        yield return new WaitForSeconds(4f);


        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);
        cam2.SetActive(true);
        yield return fader.FadeOut(2f);
      


        yield return new WaitForSeconds(7f);

        yield return fader.FadeIn(2f);
       

        enemiestoSpawn.SetActive(true);
        thundertrigger.SetActive(true);

        player.SetActive(true);
        buddy.SetActive(true);

        bridgeBlocker.SetActive(false);

        triggerCutscene.SetActive(false);
        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
