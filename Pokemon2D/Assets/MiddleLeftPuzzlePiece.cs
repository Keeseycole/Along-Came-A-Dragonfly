using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLeftPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;

    public bool middleLeftPiece = false;

    CharecterAnimator theCA;


    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingMiddleLeftPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingMiddleLeftPiece = false;
            middleLeftPiece = true;


        }


    }
}
