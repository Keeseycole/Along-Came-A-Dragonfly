using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{


    [SerializeField, HideInInspector]



    public bool isLit = false;

    public bool isRock = false;

    public bool isBottomLeftPiece = false;
    public bool isBottomRightPiece = false;


    public bool isMiddleLeftPiece = false;
    public bool isMiddleRightPiece = false;

    public bool isUpperLeftPiece = false;

    public bool isUpperRightPiece = false;



    public bool isTailPiece = false;
    public bool isLowerTailPiece = false;


    public bool well1, well2, well3, well4, well5, well6, well7, well8, well9;

    public bool rock1, rock2, rock3;

    LavaRockSpawnManager lavaRockSpawn;

  



    [SerializeField, HideInInspector]
    PlayerController player;

    private void Start()
    {
        lavaRockSpawn = FindObjectOfType<LavaRockSpawnManager>();
       
    }




    private void OnTriggerStay2D(Collider2D other)
    {
        if (isRock == true)
        {
            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingRock = true;
                this.gameObject.SetActive(false);


            }
        


        }

        if (isBottomLeftPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingBottomLeftPiece = true;
                this.gameObject.SetActive(false);


            }


        }

        if (isMiddleLeftPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingMiddleLeftPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isUpperLeftPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingUpperLeftPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isUpperRightPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingUpperRightPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isMiddleLeftPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingMiddleLeftPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isMiddleRightPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingMiddleRightPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isTailPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingTailPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isLowerTailPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingLowerTailPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (isBottomRightPiece == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingLowerRightPiece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (well1 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell1Piece = true;
                this.gameObject.SetActive(false);


            }


        }

        if (well2 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell2Piece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (well3 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell3Piece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (well4 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell4Piece = true;
                this.gameObject.SetActive(false);


            }

        }


        if (well5 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell5Piece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (well6 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell6Piece = true;
                this.gameObject.SetActive(false);


            }

        }

        if (well7 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell7Piece = true;
                this.gameObject.SetActive(false);


            }
        }

        if (well8 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell8Piece = true;
                this.gameObject.SetActive(false);


            }
        }

        if (well9 == true)
        {

            if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {

                other.GetComponent<CharecterAnimator>().IsHoldingWell9Piece = true;
                this.gameObject.SetActive(false);


            }

            
        }

        if(rock1 == true)
        {
            lavaRockSpawn.rock1= true;
        }

        if (rock2 == true)
        {
            lavaRockSpawn.rock2 = true;
        }

        if (rock3 == true)
        {
            lavaRockSpawn.rock3 = true;
        }


    }




}
