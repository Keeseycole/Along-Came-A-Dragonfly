using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter : MonoBehaviour
{
    CharecterAnimator animator;
    public float moveSpeed;

    public float OffsetY { get; private set; } = 0.3f;
    public bool IsMoving { get;  set; }

    [SerializeField] GrabObjects pickUp;

    private void Awake()
    {
        animator = GetComponent<CharecterAnimator>();
        SetPositionAndSnapToTile(transform.position);

      //  pickUp = gameObject.GetComponent<GrabObjects>();
        //pickUp.direction = new Vector2(0, -1);
    }



    public void SetPositionAndSnapToTile(Vector2 pos)
    {
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f + OffsetY;

        transform.position = pos;
    }
    public IEnumerator Move(Vector2 moveVec, Action OnMoveOver = null, bool force = false)
    {
        animator.MoveX = Mathf.Clamp(moveVec.x, -1f, 1f);
        animator.MoveY = Mathf.Clamp(moveVec.y, -1f, 1f);

        var targetPos = transform.position;
        targetPos.x += moveVec.x;
        targetPos.y += moveVec.y;

        //var ledge = CheckForLedge(targetPos);
      //  if (ledge != null)
       // {
       //     if (ledge.TryToJump(this, moveVec))
       //         yield break;
       // }


        if (!IsPathClear(targetPos) && !force)
            yield break;

      

        IsMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

       transform.position = targetPos;

        IsMoving = false;

        OnMoveOver?.Invoke();


    }

    public void HandleUpdate()
    {
        animator.IsMoving = IsMoving;
       
    }

    private bool IsPathClear(Vector3 targetPos)
    {
        var diff = targetPos - transform.position;
        var dir = diff.normalized;

        var collisionLayer = GameLayers.I.SolidLayer | GameLayers.I.InteractableLayer | GameLayers.I.PlayerLayer | GameLayers.I.MoveableObjects;
        

        if (Physics2D.BoxCast(transform.position + dir, new Vector2(0.2f, 0.2f), 0f, dir, diff.magnitude - 1, collisionLayer) == true)
            return false;

        return true;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, GameLayers.I.SolidLayer | GameLayers.I.InteractableLayer | GameLayers.I.MoveableObjects) != null)
        {
            return false;
        }

        return true;
    }

  //  Ledge CheckForLedge(Vector3 targetPos)
   // {
   //     var collider = Physics2D.OverlapCircle(targetPos, 0.15f, GameLayers.I.LedgesLayer);
    //    return collider?.GetComponent<Ledge>();
   // }

    public void LookTowards(Vector3 targetPos)
    {
        var xdiff = Mathf.Floor(targetPos.x) - Mathf.Floor(transform.position.x);
        var ydiff = Mathf.Floor(targetPos.y) - Mathf.Floor(transform.position.y);

        if (xdiff == 0 || ydiff == 0)
        {
            animator.MoveX = Mathf.Clamp(xdiff, -1f, 1f);
            animator.MoveY = Mathf.Clamp(ydiff, -1f, 1f);
        }
       
           
    }

    public CharecterAnimator Animator
    {
        get => animator;
    }

}
