using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    Spawner spawner;

    cutsceneManagerr cutscene;

    OtherworldPotralCutscene otherworldPortal;

   public  GameObject enemySpawnwrs1, enemySpawnwrs2, enemySpawnwrs3, enemySpawnwrs4;

    public GameObject trigger;

    public GameObject scenetrigger;

    public GameObject portal;

    IntoThePortalCutscene intoPortal;


    // Start is called before the first frame update
    void Start()
    {

        otherworldPortal = FindObjectOfType<OtherworldPotralCutscene>();

        cutscene = FindObjectOfType<cutsceneManagerr>();

        intoPortal = FindObjectOfType<IntoThePortalCutscene>();

        spawner = FindObjectOfType<Spawner>();

        enemySpawnwrs1 = spawner.transform.GetChild(0).gameObject;

        enemySpawnwrs2 = spawner.transform.GetChild(1).gameObject;

        enemySpawnwrs3 = spawner.transform.GetChild(2).gameObject;

        enemySpawnwrs4 = spawner.transform.GetChild(3).gameObject;

        trigger = intoPortal.transform.GetChild(0).gameObject;

        scenetrigger =  otherworldPortal.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (!enemySpawnwrs1.activeInHierarchy && !enemySpawnwrs2.activeInHierarchy &&
        !enemySpawnwrs3.activeInHierarchy && !enemySpawnwrs4.activeInHierarchy)
        {
            portal.SetActive(true);
            trigger.SetActive(true);
            scenetrigger.SetActive(true);
        }
    }
}
