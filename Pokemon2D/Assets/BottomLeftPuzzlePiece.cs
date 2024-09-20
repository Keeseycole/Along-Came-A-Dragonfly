using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLeftPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;

    public bool bottomLeftPiece = false;

    CharecterAnimator theCA;


    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingBottomLeftPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingBottomLeftPiece = false;
            bottomLeftPiece = true;


        }


    }
}
