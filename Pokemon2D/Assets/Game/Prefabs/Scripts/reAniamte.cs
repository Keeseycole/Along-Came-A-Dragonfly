using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class reAniamte : TrainerController
{
    float timeTillReaniated;

    public SpriteRenderer reanimate;

    public bool  isreanimating;

    [SerializeField]
    int timeMin = 30, timeMax = 60;

    [SerializeField]    
    public Behaviour movementScript;

    [SerializeField]
   public int timesreanimated;

    public int counttime;

    [Header("For Boss")]
    public bool isBoss;

    public int thehitCount;
  
    private void Update()
    {
        
            if (timesreanimated >= counttime)
            {
                Destroy(gameObject);
            }
        
    }
    public override void BattleLost()
    {
        base.BattleLost();
        
        timeTillReaniated = Random.Range(timeMin, timeMax);
        StartCoroutine(Reanimation());
      
    }

    public virtual IEnumerator Reanimation ()
    {
       

        gameObject.GetComponent<SpriteRenderer>().sprite = reanimate.GetComponent<SpriteRenderer>().sprite;
        isreanimating= true;
        movementScript.enabled= false;
        yield return new WaitForSeconds(timeTillReaniated);

        movementScript.enabled = true;
        isreanimating = false;
        battleLost = false;
        fov.gameObject.SetActive(true);
        StartCoroutine(Heal());
        if (isBoss)
        {
            timesreanimated += 1;
        }
    }
    
    public virtual IEnumerator Heal()
    {
           
            yield return new WaitForSeconds(.01f);

            var party = GetComponent<Party>();
            party.Creatures.ForEach(p => p.Heal());
            party.PartyUpdated();

        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isBoss)
        {
            if (other.tag == "Player")
            {
                if (other.GetComponent<CharecterAnimator>().IsSHoldingTorch == true && isreanimating == true)
                {
                    Destroy(gameObject);
                    other.GetComponent<CharecterAnimator>().IsSHoldingTorch = false;
                    // Destroy(other.GetComponent<PlayerController>().torch);
                }
            }
        }

        if (other.tag == "LavaRock" && isreanimating == true)
        {
            
            thehitCount++;

            StartCoroutine(Reanimation());
            if (thehitCount == 6)
            {
                Destroy(gameObject);
            }

        }

    }
}

 
    

    
