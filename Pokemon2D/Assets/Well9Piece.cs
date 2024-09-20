using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well9Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well9Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell9Piece == true)
        {
            well9Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell9Piece = false;


        }
    }
}
