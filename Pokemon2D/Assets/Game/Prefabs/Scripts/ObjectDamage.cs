using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    [SerializeField] public PlayerController player, buddy;

    public Creature creature, creature2;

    public float speed;

    [SerializeField] private ProjectileTrap ptrap;

    private void Start()
    {
      if (this!=null)
        creature = player.GetComponentInParent<Party>().creatures[0];
        creature2 = buddy.GetComponentInParent<Party>().creatures[0];

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, ptrap.tarPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Buddy" )
        {
            creature2.DecreaseHP(creature.MaxHP / creature.MaxHP);
            Destroy(ptrap.projectile);
           
        }

        if (other.tag == "Player" )
        {
            creature.DecreaseHP(creature.MaxHP / creature.MaxHP);
            Destroy(ptrap.projectile);
           
        }
    }
}
