using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrap : MonoBehaviour
{

    public  Lava projectile;

    public Transform fireDes, spawnPoint;

   [HideInInspector] public Vector2 tarPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator SpawnProjectile()
    {
    
        {   
        Lava theProjectile =  Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
            theProjectile.tarPos = fireDes.position;

            yield return new WaitForSeconds(.5f);





        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "Player")
        {
            StartCoroutine(SpawnProjectile());

        }

    }
}
