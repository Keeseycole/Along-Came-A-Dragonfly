using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeItem : MonoBehaviour
{
    [SerializeField]
   public GameObject item;
    

    [SerializeField, HideInInspector]

    CharecterAnimator playerAnim;

    public int freezecount;

   

    public PlayerController player;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        freezecount = 0;
    }

    private void Update()
    {
       if (freezecount == 70)
        {
           Destroy(GetComponent<FreezeItem>());
           GetComponent<CharecterAnimator>().IsSHoldingFreezeItem = false;
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lava")
        {
            freezecount++;
        }

    }


}
