using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class fishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot, bottomPivot, fishicon;

    float fishpos, fishDest;

    float fishtimer;

    [SerializeField] float timeMulti = 3f;

    float fishSpeed;

    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;

    float hookPos;

    [SerializeField] float hooksize = 0.1f;
    [SerializeField] float hookPower = 0.5f;

    float hookProgress, hookVelocity;
    [SerializeField] float hookPullPower = 0.01f;

    [SerializeField] float hookGravityPower = 0.005f;

    [SerializeField] float hookProgressDegridationPower = 0.005f;

    [SerializeField] SpriteRenderer hookSizeRenderer;

    [SerializeField] Transform progressBarComtainer;

    [SerializeField] float failTimer = 10f;

    Inventory inventory;

    bool pause = false;

    public GameObject fishingUI;

    public bool hasWon, hasLost;

    LootChance lootChance;

    ItemBase itembase;

    PlayerController player;

    GameController gc;

    FishingTrigger fishingTrigger;

    CharecterAnimator CharecterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.GetInventory();
        hasWon = false;
        hasLost = false;
        resize();
        player = FindObjectOfType<PlayerController>();

        gc =FindObjectOfType<GameController>(); 

        fishingTrigger= FindObjectOfType<FishingTrigger>();

        CharecterAnimator = FindObjectOfType<CharecterAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pause) return;
        
            Fish();
            Hook();
            ProgressCheck();
        
    }

    void Hook()
    {
        if(Input.GetMouseButton(0))
        {
            hookVelocity += hookPullPower * Time.deltaTime;
        }
        hookVelocity -= hookGravityPower* Time.deltaTime;

        hookPos += hookVelocity;

        if(hookPos - hooksize / 2 <= 0f && hookVelocity < 0f)
        {
            hookVelocity = 0f;
        }
        if(hookPos + hooksize / 2 >= 1f && hookVelocity > 0f)
        {
            hookVelocity = 0f;
        }

        hookPos = Mathf.Clamp(hookPos, hooksize / 2, 1 - hooksize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPos);
    }

    public void Fish()
    {
        fishtimer -= Time.time;
        if (fishtimer < 0)
        {
            fishtimer = UnityEngine.Random.value * timeMulti;

            fishDest = UnityEngine.Random.value;
        }
        fishpos = Mathf.SmoothDamp(fishpos, fishDest, ref fishSpeed, smoothMotion);
        fishicon.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishpos);
    }
    public void resize()
    {
        Bounds b = hookSizeRenderer.bounds;
        float ysize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = (distance / ysize * hooksize);
        hook.localScale= ls;
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressBarComtainer.localScale;
        ls.y = hookProgress;
        progressBarComtainer.localScale = ls;

        float min = hookPos - hooksize / 2;

        float max = hookPos + hooksize / 2;

        if(min < fishpos && fishpos< max)
        {
            hookProgress += hookPower * Time.deltaTime;
        } else
        {
            hookProgress -= hookProgressDegridationPower* Time.deltaTime;

            failTimer -= Time.deltaTime;
            if(failTimer <= 0f) 
            {
                Lose(player.transform);
                Reset();
               
            }
            hasLost = false;
        }

        if(hookProgress >= 1f)
        {
          Catch();
            Reset();
        }
        hasWon = false;
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
   
    }

  

    private void Reset()
    {
        hookProgress = 0f;
        failTimer = 10f;
    }

    public void Catch()
    {
        
       hasWon= true;
   


        ItemBase currentCatch = SceneSystem.currentLevelManager.ItemfromFishing();

        inventory.AddItem(currentCatch);

       if(currentCatch.GetItemType == ItemType.Fish)
       {
           IDSystem.i.addFishID((FishItem)currentCatch);
        }


        fishingTrigger.CaughtFish(currentCatch, player.transform);
        player.ignoreInput = false;
         
        fishingUI.gameObject.SetActive(false);
    
    }

    public void Lose( Transform initer)
    {
        var animator = initer.GetComponent<CharecterAnimator>();
        Debug.Log("has lost");
        animator.IsFishing = false;
        hasLost = true;
        fishingUI.gameObject.SetActive(false);
        player.ignoreInput = false;
        gc.StateMachine.Pop();


    }

}
