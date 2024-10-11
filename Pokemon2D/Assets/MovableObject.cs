using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] float speed = .1f;
    [SerializeField] bool isIceBlock = true;

    [SerializeField] SideCollider colliderUp, colliderDown, colliderLeft, colliderRight;

    public GameObject thecollider;
    private bool IsMoving;
    private bool KeepMoving = true;


    public float timer;


    public IEnumerator Move(Vector3 direction)
    {
        if (CheckDirection(direction, true))
        {
            while (KeepMoving && CheckDirection(direction )) 
            {
                if (!IsMoving)
                {
                    Vector3 targetPos = transform.position + direction;
                    IsMoving = true;

                    // Movement of the MovableObject
                    while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                        yield return null;
                    }
                    transform.position = targetPos;
                    IsMoving = false;

                    if (!isIceBlock)
                        KeepMoving = false;
                }
            }
            if (!isIceBlock)
                KeepMoving = true;
        }
    }

    private bool CheckDirection(Vector2 direction, bool firstTouch = false)
    {
        
        // Coordinates
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + direction;
        if (firstTouch)
        {


            switch (direction)
            {
                case var _ when direction.y > 0.1f: // Moving up
                    if (colliderDown.isPlayerTouchingSide == false)
                    {

                        return false;
                    }
                    break;

                case var _ when direction.y < -0.1f: // Moving down
                    if (colliderUp.isPlayerTouchingSide == false)
                    {

                        return false;
                    }
                    break;

                case var _ when direction.x > 0.1f: // Moving right
                    if (colliderLeft.isPlayerTouchingSide == false)
                    {

                        return false;
                    }
                    break;

                case var _ when direction.x < -0.1f: // Moving left
                    if (colliderRight.isPlayerTouchingSide == false)
                    {

                        return false;
                    }
                    break;
            }
        }

    // Layers
    var collisionLayer = GameLayers.I.SolidLayer | GameLayers.I.InteractableLayer | GameLayers.I.PlayerLayer | GameLayers.I.MoveableObjects;

        if (Physics2D.BoxCast(targetPos, new Vector2(0.1f, 0.1f), 0f, direction, direction.magnitude - 1, collisionLayer) == true)
            return false;
        return true;
    }


   // private void OnTriggerStay2D(Collider2D collision)
   // {
      //  if (collision.tag == "Block")
        //{
         //   timer -= Time.deltaTime;
          //  if (timer <= 0)
          //  {
          //      thecollider.gameObject.SetActive(false);
          //  } 
          //  if(timer >=1)
           // {
           //     thecollider.gameObject.SetActive(true);
           // }
       // }
      // }
   }
  



