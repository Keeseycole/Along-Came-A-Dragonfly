using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well8Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well8Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell8Piece == true)
        {
            well8Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell8Piece = false;


        }
    }
}
