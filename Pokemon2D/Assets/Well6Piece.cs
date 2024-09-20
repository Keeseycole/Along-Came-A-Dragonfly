using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well6Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well6Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell6Piece == true)
        {
            well6Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell6Piece = false;


        }
    }
}
