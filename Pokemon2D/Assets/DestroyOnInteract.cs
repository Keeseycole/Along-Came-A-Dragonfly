using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInteract : MonoBehaviour
{

   public bool canDestroy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.SetActive(false);

                if(canDestroy == true)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
