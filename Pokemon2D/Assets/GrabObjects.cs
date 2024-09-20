using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;

    [SerializeField] CharecterAnimator charAnim;

   

    public GameObject itemToHold;

    public bool isgrabbed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (itemToHold)
            {
                itemToHold.transform.position = transform.position + direction;
                itemToHold.transform.parent = null;

                if (itemToHold.GetComponent<Rigidbody2D>())
                    itemToHold.GetComponent<Rigidbody2D>().simulated = true;
                itemToHold = null;
                
            }
            else

            {
                Collider2D pickupItem = Physics2D.OverlapCircle(transform.position + direction, .4f, pickUpMask);
                if (pickupItem)
                {
                    //isgrabbed = true;
                    itemToHold = pickupItem.gameObject;
                    itemToHold.transform.position = holdSpot.position;
                    itemToHold.transform.parent = transform;
                    if (itemToHold.GetComponent<Rigidbody2D>())
                    {
                        itemToHold.GetComponent<Rigidbody2D>().simulated = false;
                    }
                }              
            }
        }
    }

    public Vector3 direction { get { return new Vector3(charAnim.MoveX, charAnim.MoveY); } }
}

       


