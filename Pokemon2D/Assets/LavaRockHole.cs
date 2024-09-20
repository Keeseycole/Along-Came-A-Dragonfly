using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRockHole : MonoBehaviour
{
    [SerializeField]
    GameObject emptyHole;
    [SerializeField]
    GameObject filledHole;

    public bool isFilled = false;

    CharecterAnimator theCA;

    filledHoles filledHoleMan;



    private void Awake()
    {
        theCA= GetComponent<CharecterAnimator>();
    }
    void Start()
    {
       
        gameObject.GetComponent<SpriteRenderer>().sprite = emptyHole.GetComponent<SpriteRenderer>().sprite;

        filledHoleMan = FindObjectOfType<filledHoles>();

      


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player")
        {       
                gameObject.GetComponent<SpriteRenderer>().sprite = filledHole.GetComponent<SpriteRenderer>().sprite;
                isFilled = true;
            other.GetComponent<CharecterAnimator>().IsHoldingRock = false;
          
        }
    }
}

