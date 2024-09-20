using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElricImprisonedManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    [SerializeField] public GameObject elricImprisonedCutscene;

    public GameObject player;
    public GameObject buddy;

    PlayerController thePlayer;

    cutsceneManagerr cutscenes;

    ElricImprisonedManager elricImprisoned;


    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        elricImprisonedCutscene = cutscenes.cutscenes[49].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        elricImprisoned = FindObjectOfType<ElricImprisonedManager>();

        enemies[0] = elricImprisoned.gameObject.transform.GetChild(0).gameObject;

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

        elricImprisonedCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(5.5f);
        yield return fader.FadeIn(2f);

        elricImprisonedCutscene.SetActive(false);
  
        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
