using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkElricHideManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    [SerializeField] public GameObject darkElricReapear;

    public GameObject player;
    public GameObject buddy;

    PlayerController thePlayer;

    cutsceneManagerr cutscenes;

    ElricDarkManager elricDarkManager;

    DarkElricHideManager darkElricHide;

    DarkEkricDefeatManager darkElricDefeat;


    public GameObject hide1, hide2, hide3, hide4;

    public GameObject darkelric;


    // Start is called before the first frame update
    void Start()
    {
        darkElricDefeat = FindObjectOfType<DarkEkricDefeatManager>();

        darkElricHide = FindObjectOfType<DarkElricHideManager>();

        hide1 = darkElricHide.gameObject.transform.GetChild(0).gameObject;

        hide2 = darkElricHide.gameObject.transform.GetChild(1).gameObject;

        hide3 = darkElricHide.gameObject.transform.GetChild(2).gameObject;

        hide4 = darkElricHide.gameObject.transform.GetChild(3).gameObject;

        darkelric = darkElricDefeat.gameObject.transform.GetChild(1).gameObject;



        cutscenes = FindObjectOfType<cutsceneManagerr>();

        enemies[0] = darkElricHide.gameObject.transform.GetChild(4).gameObject;

       


        darkElricReapear = cutscenes.cutscenes[53].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        elricDarkManager = FindObjectOfType<ElricDarkManager>();

       

    }

    // Update is called once per frame
    void Update()
    {

        if (!hide2.activeInHierarchy && !hide1.activeInHierarchy
          && !hide3.activeInHierarchy && !hide4.activeInHierarchy)
        {
            enemies[0].SetActive(true);
        }

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

        darkElricReapear.SetActive(true);
       

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(5f);
        yield return fader.FadeIn(2f);

        darkElricReapear.SetActive(false);
        

        player.SetActive(true);
        buddy.SetActive(true);
        darkelric.SetActive(true);




        yield return fader.FadeOut(2f);

      

        this.gameObject.SetActive(false);
    }



}
