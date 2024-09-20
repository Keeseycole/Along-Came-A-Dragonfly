using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;

    public bool farmiddleRightPiece = false;

    CharecterAnimator theCA;


    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingTailPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingTailPiece = false;
            farmiddleRightPiece = true;


        }


    }
}
