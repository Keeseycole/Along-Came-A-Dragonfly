using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSnailEnemies : MonoBehaviour
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;

    public GameObject darkiceSnail;

    DarkIceSnailManager darkIceSnailMan;

    DarkIceSnailDefeatCutscene darkIceSnaildefeat;


   public GameObject trigger;


    public GameObject player;
    public GameObject buddy;


    IceSnailEnemies icesnailEnemys;
    PlayerController thePlayer;

    BattleSystem battlesystem;

    cutsceneManagerr cutscenes;


    // Start is called before the first frame update
    void Start()
    {

        darkIceSnaildefeat = FindObjectOfType<DarkIceSnailDefeatCutscene>();
        icesnailEnemys = FindObjectOfType<IceSnailEnemies>();

        enemies[0] = icesnailEnemys.transform.GetChild(0).gameObject;

        enemies[1] = icesnailEnemys.transform.GetChild(1).gameObject;

        enemies[2] = icesnailEnemys.transform.GetChild(2).gameObject;

        enemies[3] = icesnailEnemys.transform.GetChild(3).gameObject;

        enemies[4] = icesnailEnemys.transform.GetChild(4).gameObject;

        enemies[5] = icesnailEnemys.transform.GetChild(5).gameObject;

        darkIceSnailMan = FindObjectOfType<DarkIceSnailManager>();
 
        player = FindObjectOfType<PlayerController>().gameObject;
        buddy = FindObjectOfType<BuddyController>().gameObject;
        battlesystem = FindObjectOfType<BattleSystem>();
        thePlayer = FindObjectOfType<PlayerController>();
        functionCalled = false;
        fader = FindObjectOfType<Fader>();

        trigger = darkIceSnailMan.transform.GetChild(0).gameObject;

        darkiceSnail = darkIceSnaildefeat.transform.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (enemies.Count <= 0)
        {

            if (!functionCalled)
            {

                functionCalled = true;
                
                trigger.SetActive(true);

                darkiceSnail.SetActive(true);
            }
        }
    }

  
}
