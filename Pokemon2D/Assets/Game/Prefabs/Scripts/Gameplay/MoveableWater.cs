using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableWater : MonoBehaviour
{

    PlayerController player;
   

    MoveableWater instance;

    CharecterAnimator charecterAnim;

    Charecter charecter;

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<PlayerController>();

        charecterAnim = FindObjectOfType<CharecterAnimator>();

        charecter= FindObjectOfType<Charecter>();
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharecterAnimator>().IsSwimming = true;
        }

        if (other.gameObject.tag == "Buddy")
        {
            other.GetComponent<CharecterAnimator>().IsSwimming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharecterAnimator>().IsSwimming = false;
        }

        if (other.gameObject.tag == "Buddy")
        {
            other.GetComponent<CharecterAnimator>().IsSwimming = false;
        }
    }


}

    


