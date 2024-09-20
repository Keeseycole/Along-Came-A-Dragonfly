using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellTopLeftPiece : MonoBehaviour
{
    [SerializeField]
    GameObject well1Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell1Piece == true)
        {
            well1Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell1Piece = false;


        }
    }
    }
