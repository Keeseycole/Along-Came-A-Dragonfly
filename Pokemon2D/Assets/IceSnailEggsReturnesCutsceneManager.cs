using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSnailEggsReturnesCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject IceSnailRescueCutscene;

    public List<GameObject> enemies;

    PlayerController thePlayer;
    BuddyController theBuddy;


    cutsceneManagerr cutscenes;

    public GameObject iceSnaill1, iceSnaill2;

    public GameObject iceSnaileggHole;

    public GameObject freezeItem;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        IceSnailRescueCutscene = cutscenes.cutscenes[62].gameObject;


        thePlayer = FindObjectOfType<PlayerController>();
        theBuddy = FindObjectOfType<BuddyController>();
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
        iceSnaill1.SetActive(false);
        thePlayer.gameObject.SetActive(false);
        theBuddy.gameObject.SetActive(false);

        IceSnailRescueCutscene.SetActive(true);
        yield return fader.FadeOut(3f);

        
        iceSnaileggHole.SetActive(true);
        yield return new WaitForSeconds(22f);
        yield return fader.FadeIn(2f);
        IceSnailRescueCutscene.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theBuddy.gameObject.SetActive(true);
      
        iceSnaill2.SetActive(true);
        freezeItem.SetActive(true);
        yield return fader.FadeOut(2f);
        
        this.gameObject.SetActive(false);
    }
}
