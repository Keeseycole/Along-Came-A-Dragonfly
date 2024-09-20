using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Lava
{   
    public bool hasFallen;
  
    public bool hasPassed;

    public float fallTime;

    public Transform respawnPoint;

    private Encounter enemy;
 
    public Fader fader;
  
    BuddyController buddy;
    

    private void Start()
    {
        buddy= FindObjectOfType<BuddyController>();
        fader= FindObjectOfType<Fader>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator Fall()
    {
       
        hasFallen = true;

        yield return fader.FadeIn(.2f); 
     
       
        player.transform.position = respawnPoint.position;
   
        creature.DecreaseHP(creature.MaxHP / creature.MaxHP);

        buddy.DeActivateBuddy();

        hasFallen = false;

        yield return fader.FadeOut(1f);

        buddy.ActivateBuddy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "Player")
        {
          
         StartCoroutine(Fall());
                      
        }

        if (other.tag == "Enemy")
        {
          
            Destroy(enemy);

        }

    }
}
