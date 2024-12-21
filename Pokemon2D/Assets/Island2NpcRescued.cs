using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island2NpcRescued : MonoBehaviour
{
    public GameObject npc2Island, npc2Rescued, npc2WifeAfterRescue, npc2WifeBeforeRescue, npc2KidBefore,
        npc2KidAfter, bed, chair;

    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            npc2Island.SetActive(false);
            npc2Rescued.SetActive(true);
            npc2WifeAfterRescue.SetActive(true);
            npc2WifeBeforeRescue.SetActive(false);
            npc2KidBefore.SetActive(false);
            npc2KidAfter.SetActive(true);
            bed.SetActive(false);
            chair.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
