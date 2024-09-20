using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRightPuzzlePiece : MonoBehaviour
{
    [SerializeField]
    GameObject fishStatuePiece;


    public bool topRightPiece = false;

    CharecterAnimator theCA;

    [SerializeField]

    private void Awake()
    {
        theCA = GetComponent<CharecterAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharecterAnimator>().gameObject == true && other.tag == "Player" && other.GetComponent<CharecterAnimator>().IsHoldingUpperRightPiece == true)
        {
            fishStatuePiece.SetActive(true);

            other.GetComponent<CharecterAnimator>().IsHoldingUpperRightPiece = false;
            topRightPiece = true;


        }


    }
}
