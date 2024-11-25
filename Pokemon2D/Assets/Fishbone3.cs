using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbone3 : MonoBehaviour
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
            player.hasFishBones3 = true;
            Destroy(this.gameObject);
        }
    }
}
