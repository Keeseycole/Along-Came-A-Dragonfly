using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockResetSwitchSingle : MonoBehaviour
{
    public GameObject[] blocks;

    public Transform[] points;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            blocks[0].transform.position = points[0].transform.position;
        

        }
    }
}
