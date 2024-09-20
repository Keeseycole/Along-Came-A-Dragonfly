using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSnailEggEvent : MonoBehaviour
{
    [SerializeField] TRiggerableEvent trigEvent;

    public PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player.hasSnailEggs == true)
        {
            if (trigEvent != null)
            {
                trigEvent.StartCutscene();
            }
            Destroy(this);

        }
    }
}
