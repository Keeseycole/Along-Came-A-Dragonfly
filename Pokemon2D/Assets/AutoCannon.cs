using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AutoCannon : MonoBehaviour
{
    public GameObject cannon;

    public Transform fireDes, firePoint;

    public AutoProjectile lavaRock;

    [SerializeField] public bool IsInstanciated;

    public bool isOn, isOff;

    public BoxCollider2D triggerArea;

   
    private void Start()
    {
       
        isOn = true;
    }
    private void Update()
    {
        StartCoroutine(SpawnLavaRock());
       
    }

    IEnumerator SpawnLavaRock()
    {
        if (!IsInstanciated)
        {
            IsInstanciated = true;
            AutoProjectile newLavaRockProjectile = Instantiate(lavaRock, firePoint.transform.position, Quaternion.identity);


            newLavaRockProjectile.tarPos = fireDes.position;

            yield return new WaitForSeconds(.5f);

            IsInstanciated = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {       
           Destroy(gameObject);
     
        }
    }
}

  

