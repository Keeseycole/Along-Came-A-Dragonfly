using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island4NPCRescued : MonoBehaviour
{
    public GameObject npc4Island, npc4Rescued, firePlaceBefore, firePlaceAfter;

    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            npc4Island.SetActive(false);
            npc4Rescued.SetActive(true);
            firePlaceAfter.SetActive(true);
            firePlaceBefore.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
