using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Lava : MonoBehaviour
{
   public PlayerController player;

    public Creature creature;

   [HideInInspector] public List<GameObject> lava;

    // for non tiles
   [HideInInspector]public Vector2 tarPos;
    public float speed;
    public bool isProjectile;
    public bool isSpawned;
    public bool isTile;

    public float projectileTime;


    public GameObject rock1, rock2, rock3;

    LavaRocks lavaRocks;

    ItemPickup itemPickup;

    LavaRockSpawnManager lavaRockSpawn;


    private void Awake()
    {
        
     player = FindObjectOfType<PlayerController>();
   
     creature = player.GetComponentInParent<Party>().creatures[0];

        lavaRocks = FindObjectOfType<LavaRocks>();

        itemPickup = FindObjectOfType<ItemPickup>();

        lavaRockSpawn = FindObjectOfType<LavaRockSpawnManager>();
    
    }
    private void Start()
    {
     
    }
    private void Update()
    {     
        if(gameObject.name == "arrow projectile(Clone)" && isActiveAndEnabled)
        {
            isSpawned = true;
        } else
        {
            isSpawned = false;
        }


        if (isProjectile == true)
        {
            if (isSpawned == true)
            {
                projectileTime -= Time.deltaTime;

                transform.position = Vector2.MoveTowards(transform.position, tarPos, speed * Time.deltaTime);

                if (projectileTime <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (isTile == true)
        {
              if (other.tag == "Player")
            {
                creature.DecreaseHP(creature.MaxHP / creature.MaxHP);
            }
        }

        if (other.GetComponent<CharecterAnimator>().IsHoldingRock == true)
        {
          other.GetComponent<CharecterAnimator>().IsHoldingRock = false;

            if (lavaRockSpawn.rock1 == true)
            {
                rock1.SetActive(true);
                
            }

            if (lavaRockSpawn.rock2 == true)
            {
                rock2.SetActive(true);
                
            }

            if (lavaRockSpawn.rock3 == true)
            {
                rock3.SetActive(true);

            }



        }

     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTile == true)
        {
            if (other.tag == "Player")
                if (other.GetComponent<CharecterAnimator>().IsSHoldingFreezeItem == true)
                {
                    Destroy(gameObject);

                } 
        }

        if (isTile == false)
        {
             if (other.tag == "Player")
            {
                creature.DecreaseHP(creature.MaxHP / creature.MaxHP);
                

            }
        }
    }
}


   

