using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRemover : MonoBehaviour
{
    [SerializeField] TRiggerableEvent trigEvent;

    public bool shouldDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(trigEvent!= null)
            {
                trigEvent.StartCutscene();
            }
            Destroy(this);

            if (shouldDestroy == true)
            {
                Destroy(this.gameObject);
            }
        }

        if(collision.tag == "Snowball")
        {
            Destroy(this.gameObject);
        }

      
    }
}
