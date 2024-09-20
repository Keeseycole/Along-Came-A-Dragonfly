using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRightPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;

    public bool bottomRightPiece = false;

    CharecterAnimator theCA;


    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingLowerRightPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingLowerRightPiece = false;
            bottomRightPiece = true;


        }


    }
}
