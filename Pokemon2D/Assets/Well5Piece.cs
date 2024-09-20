using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well5Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well5Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell5Piece == true)
        {
            well5Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell5Piece = false;


        }
    }
}
