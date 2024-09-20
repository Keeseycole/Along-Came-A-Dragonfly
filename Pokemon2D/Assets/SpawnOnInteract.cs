using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnInteract : MonoBehaviour
{
    public GameObject objtospawn;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               this.gameObject.SetActive(false);
                objtospawn.gameObject.SetActive(true);
                Destroy(this.gameObject);
             
            }       
        }
    }
}
