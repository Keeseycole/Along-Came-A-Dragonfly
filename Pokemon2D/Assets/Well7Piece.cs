using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well7Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well7Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell7Piece == true)
        {
            well7Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell7Piece = false;


        }
    }
}
