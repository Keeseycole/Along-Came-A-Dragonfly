using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well3Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well3Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell3Piece == true)
        {
            well3Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell3Piece = false;
            

        }
    }
}
