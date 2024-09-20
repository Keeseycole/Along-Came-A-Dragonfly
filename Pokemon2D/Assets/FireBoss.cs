using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss : reAniamte
{
 
    public int hitCount;

    public override void BattleLost()
    {
        base.BattleLost();

    }

    public  override IEnumerator Reanimation()
    {


        gameObject.GetComponent<SpriteRenderer>().sprite = reanimate.GetComponent<SpriteRenderer>().sprite;
        isreanimating = true;
        movementScript.enabled = false;
        yield return new WaitForSeconds(1f);

        movementScript.enabled = true;
        isreanimating = false;
        battleLost = false;
        fov.gameObject.SetActive(true);
        StartCoroutine(Heal());
       
            timesreanimated += 1;
    }

    public override IEnumerator Heal()
    {

        yield return new WaitForSeconds(.01f);

        var party = GetComponent<Party>();
        party.Creatures.ForEach(p => p.Heal());
        party.PartyUpdated();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
            if (other.tag == "LavaRock" && isreanimating == true)
            {
                hitCount++;

            StartCoroutine(Reanimation());
            if (hitCount == 3)
                {
                    Destroy(gameObject);
                }
                    
            }
        
    }

}

