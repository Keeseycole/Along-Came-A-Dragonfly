using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] public float spawntime;

    [SerializeField] public  GameObject[] spawn1enimiesToSpawn;

    [SerializeField] public GameObject[] spawn2enimiesToSpawn;

    [SerializeField] public GameObject[] spawn3enimiesToSpawn;

    [SerializeField] public GameObject[] spawn4enimiesToSpawn;

    [SerializeField] private GameObject[] spawners;

    [SerializeField] private GameObject objtoSpawn;

    [SerializeField] private GameObject[] spawnpoints;

    public float enemyCount, enemyCount2, enemyCount3, enemyCount4;

    [SerializeField] private bool canSpawn = true;

    public static SpawnManager instance { get; set; }

 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnEnemy2());
        StartCoroutine(SpawnEnemy3());
         StartCoroutine(SpawnEnemy4());

        spawners[0] = spawnpoints[0];
        spawners[1] = spawnpoints[1];
        spawners[2] = spawnpoints[2];
        spawners[3] = spawnpoints[3];


       // objtoSpawn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnpoints[0] == null)
        {
           StopCoroutine(SpawnEnemy());

        }

        if (spawnpoints[1] == null)
        {
            StopCoroutine(SpawnEnemy2());

        }

        if (spawnpoints[2] == null)
        {
           StopCoroutine(SpawnEnemy3());

        }


        if (spawnpoints[3] == null)
        {
            StopCoroutine(SpawnEnemy4());

        }


        if (enemyCount <= 0 && enemyCount2 <= 0 && enemyCount3 <= 0)
        {
           // objtoSpawn.SetActive(true);
        }

    }

    public static SpawnManager GetInstance()
    {
        return instance;
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawntime);

        if (canSpawn && enemyCount < 15)
        {
            yield return wait;

            int rand = Random.Range(0, spawn1enimiesToSpawn.Length);

            GameObject enemiestospawn = spawn1enimiesToSpawn[rand];

            var enemy1 = Instantiate(enemiestospawn, spawnpoints[0].transform.position, Quaternion.identity);

            enemyCount++;

        }

    }

    private IEnumerator SpawnEnemy2()
    {
        WaitForSeconds wait = new WaitForSeconds(spawntime);

        while (canSpawn && enemyCount2 < 15)
        {
            yield return wait;

            int rand2 = Random.Range(0, spawn2enimiesToSpawn.Length);

            GameObject enemiestospawn2 = spawn2enimiesToSpawn[rand2];

            var enemy2 = Instantiate(enemiestospawn2, spawnpoints[1].transform.position, Quaternion.identity);

            enemyCount2++;
        }
    }

    private IEnumerator SpawnEnemy3()
    {
        WaitForSeconds wait = new WaitForSeconds(spawntime);

        while (canSpawn && enemyCount3 < 15)
        {
            yield return wait;

            int rand3 = Random.Range(0, spawn3enimiesToSpawn.Length);

            GameObject enemiestospawn3 = spawn3enimiesToSpawn[rand3];

            var enemy3 = Instantiate(enemiestospawn3, spawnpoints[2].transform.position, Quaternion.identity);

            enemyCount3++;
        }
    }

    private IEnumerator SpawnEnemy4()
    {
        WaitForSeconds wait = new WaitForSeconds(spawntime);

        while (canSpawn && enemyCount4 < 15)
        {
            yield return wait;

            int rand4 = Random.Range(0, spawn4enimiesToSpawn.Length);

            GameObject enemiestospawn4 = spawn4enimiesToSpawn[rand4];

            var enemy4 = Instantiate(enemiestospawn4, spawnpoints[3].transform.position, Quaternion.identity);

            enemyCount4++;
        }
    }
}
