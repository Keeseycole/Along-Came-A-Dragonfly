using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetMarianaCutsceneManager : TRiggerableEvent
{
    public List<GameObject> meetMarianaTrigger;


    public bool functionCalled = false;

    public Fader fader;

    [SerializeField] public GameObject triggerCutscene;


    cutsceneManagerr cutscenes;


    public GameObject player;
    public GameObject buddy;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscenes.cutscenes[11].gameObject;

        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        if (meetMarianaTrigger.Count <= 0)
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
        triggerCutscene.SetActive(true);
        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(22f);
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(1f);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        buddy.SetActive(true);
        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
