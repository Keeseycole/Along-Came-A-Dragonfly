using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphinusFlashbackCutsceneManager : TRiggerableEvent
{
    public bool functionCalled = false;

    public List<GameObject> trigger;


    public Fader fader;

    PlayerController thePlayer;

    BattleSystem battlesystem;

    public GameObject player;

    cutsceneManagerr cutscene;

    [SerializeField] public GameObject triggerCutscene;

    public GameObject flowers,  ophinusBurningHouse, mariana, Ophinus, ophinusHouse;

    public GameObject nextSceneTrigger;

    BurningHousenMariana burningHousenMariana;


    // Start is called before the first frame update
    void Start()
    {

        burningHousenMariana = FindObjectOfType<BurningHousenMariana>();

        battlesystem = FindObjectOfType<BattleSystem>();

        player = FindObjectOfType<PlayerController>().gameObject;


        thePlayer = FindObjectOfType<PlayerController>();

        functionCalled = false;

        fader = FindObjectOfType<Fader>();


        cutscene = FindObjectOfType<cutsceneManagerr>();

        triggerCutscene = cutscene.cutscenes[26].gameObject;

        ophinusBurningHouse = burningHousenMariana.transform.GetChild(0).gameObject;

        mariana = burningHousenMariana.transform.GetChild(1).gameObject;

        Ophinus = burningHousenMariana.transform.GetChild(2).gameObject;

        ophinusHouse = burningHousenMariana.transform.GetChild(3).gameObject;

        flowers = burningHousenMariana.transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.Count <= 0)
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
        player.SetActive(false);
        yield return new WaitForSeconds(.2f);


        triggerCutscene.SetActive(true);

        flowers.SetActive(true);
        ophinusBurningHouse.SetActive(false);
        mariana.SetActive(false);
        Ophinus.SetActive(false);
        ophinusHouse.SetActive(false);
        yield return new WaitForSeconds(31f);

        yield return fader.FadeOut(2f);
        yield return new WaitForSeconds(35f);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        yield return fader.FadeIn(2f);
        triggerCutscene.SetActive(false);
        player.SetActive(true);
        yield return fader.FadeOut(2f);
        nextSceneTrigger.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
