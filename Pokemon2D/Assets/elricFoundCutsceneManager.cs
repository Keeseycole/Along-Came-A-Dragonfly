using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elricFoundCutsceneManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    public GameObject spawn;

    [SerializeField] public GameObject elricFoundCutscene;



    public GameObject player;
    public GameObject buddy;



    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;

    IceSnailEnemies iceSnailEnemies;

    elricFoundCutsceneManager elricFoundCutsceneMan;

    // Start is called before the first frame update
    void Start()
    {
        cutscenes = FindObjectOfType<cutsceneManagerr>();

        elricFoundCutscene = cutscenes.cutscenes[48].gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        elricFoundCutsceneMan = FindObjectOfType<elricFoundCutsceneManager>();

        spawn = elricFoundCutsceneMan.gameObject.transform.GetChild(1).gameObject;
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

        elricFoundCutscene.SetActive(true);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(12f);
        yield return fader.FadeIn(2f);

        elricFoundCutscene.SetActive(false);
        player.transform.position = spawn.transform.position;

        buddy.transform.position = spawn.transform.position;
        player.SetActive(true);
        buddy.SetActive(true);

        yield return fader.FadeOut(2f);

        this.gameObject.SetActive(false);
    }
}
