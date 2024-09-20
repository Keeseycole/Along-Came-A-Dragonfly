using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoProjectile : MonoBehaviour
{
    [SerializeField] public PlayerController player, buddy;
    public Creature creature, creature2;

    public Vector2 tarPos;
    public float speed;

    
    public static AutoProjectile instance { get; set; }



    private void Start()
    {

        creature = FindObjectOfType<Party>().creatures[0];
       // creature2 = FindObjectOfType<Party>().creatures[1];

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tarPos, speed * Time.deltaTime);

    }
    private void OnTriggerStay2D(Collider2D other)
    {


        if (other.tag == "Buddy")
        {
            creature2.DecreaseHP(creature.MaxHP / creature.MaxHP);
        }

        if (other.tag == "Player")
        {
            creature.DecreaseHP(creature.MaxHP / creature.MaxHP);
        }



        StartCoroutine(DestroyTime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Destroy(gameObject);
        }
       
    }

    public IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
   
}
