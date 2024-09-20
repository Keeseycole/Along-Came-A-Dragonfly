using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{

    public AutoProjectile lightningbolt;

    public float speed;

    public GameObject lightningZone;

    public List<Transform> spawnPoints;

    public List<GameObject> Enemies;

    public float minTime, maxTime;

    public GameObject sailCutsceneTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count > 0)
        {
            lightningZone.SetActive(true);
            StartCoroutine(Eruption());
        }
       
        if (Enemies.Count <= 0)
        {
            sailCutsceneTrigger.SetActive(true);
            lightningZone.SetActive(false);
        }
    }

    
    public IEnumerator Eruption()
    {
        float RandomSpawnTime = Random.Range(minTime, maxTime);
         while (Enemies.Count >= 0)
         {

          yield return new WaitForSeconds(RandomSpawnTime);
       
           AutoProjectile newLavaRockProjectile = Instantiate(lightningbolt, spawnPoints[Random.Range(0, 53)].transform.position, Quaternion.identity);


            yield return new WaitForSeconds(.001f);
            Destroy(newLavaRockProjectile);



        }

    }
}
