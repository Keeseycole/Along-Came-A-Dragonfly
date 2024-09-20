using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well4Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well4Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell4Piece == true)
        {

            other.GetComponent<CharecterAnimator>().IsHoldingWell4Piece = false;
            well4Piece.SetActive(true);



        }
    }
}
