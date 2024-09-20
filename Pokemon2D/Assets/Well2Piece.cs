using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well2Piece : MonoBehaviour
{
    [SerializeField]
    GameObject well2Piece;




    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingWell2Piece == true)
        {
            well2Piece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingWell2Piece = false;


        }
    }
}
