using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public enum Side { Top, Bottom, Left, Right }
    public Side colliderSide;
    public bool isPlayerTouchingSide = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Player enter side.");

        if (other.CompareTag("Player"))
        {
            isPlayerTouchingSide = true;
            Debug.Log($"Player is touching the {colliderSide} side.");
            // Handle specific logic for when the player touches this side
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerTouchingSide = false;
            Debug.Log($"Player left the {colliderSide} side.");
        }
    }
}
