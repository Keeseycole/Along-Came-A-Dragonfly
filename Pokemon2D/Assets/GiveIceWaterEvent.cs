using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveIceWaterEvent : MonoBehaviour
{
    [SerializeField] TRiggerableEvent trigEvent;

    public PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.isInTrigger= true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.isInTrigger = false;

        }
    }
}
