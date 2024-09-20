using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptileIceDungCutsceneManager : TRiggerableEvent
{
    public List<GameObject> ReptileIceTrigger;

    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;


    PlayerController thePlayer;

    BuddyController theBuddy;


    cutsceneManagerr cutscenes;
    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[13].gameObject;

        thePlayer = FindObjectOfType<PlayerController>();

        theBuddy = FindObjectOfType<BuddyController>();

        functionCalled = false;
        fader = FindObjectOfType<Fader>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ReptileIceTrigger.Count <= 0)
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
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(25f);
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(1f);
        triggerCutscene.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theBuddy.gameObject.SetActive(true);
        yield return fader.FadeOut(2f);

      
        this.gameObject.SetActive(false);
    }
}
