using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
 
    public  Fader fader;

    public PlayerController player;

    public BuddyController buddy;

    private void Awake()
    {
        fader = FindObjectOfType<Fader>();
        player = FindObjectOfType<PlayerController>();
    }

    IEnumerator Teleport()
    {
       

        if (player == null) 
        {
            Debug.LogWarning("Player cannot be found");
            yield break;
        }
        player.ignoreInput = true;
        player.blocker.SetActive(true);
        yield return fader.FadeIn(1f);

        buddy.DeActivateBuddy();

        
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().transform.position;

        
       
        yield return fader.FadeOut(1f);
        player.blocker.SetActive(false);
        buddy.ActivateBuddy();
        player.ignoreInput = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Teleporter"))
        {
              StartCoroutine(Teleport());
            Debug.Log("is teleported");
            currentTeleporter = other.gameObject;
        }       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if(other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    
}
