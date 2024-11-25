using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishbone4 : MonoBehaviour
{
    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.hasFishBones4 = true;
            Destroy(this.gameObject);
        }
    }
}
