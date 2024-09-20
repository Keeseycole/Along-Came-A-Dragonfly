using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerTailPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;

    public bool lowerTailPiece = false;

    CharecterAnimator theCA;


    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingLowerTailPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingLowerTailPiece = false;
            lowerTailPiece = true;


        }


    }
}
