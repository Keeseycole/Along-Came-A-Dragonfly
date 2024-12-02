using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island1NpcRescued : MonoBehaviour
{
    public GameObject npc1Island, npc1Rescued;

    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            npc1Island.SetActive(false);
            npc1Rescued.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
