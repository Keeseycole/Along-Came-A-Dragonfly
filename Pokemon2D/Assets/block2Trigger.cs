using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block2Trigger : MonoBehaviour
{

    
    PictureBlockTriggers blockTriggers;

    



    private void Start()
    {
        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

       

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock2")
        {

           
            this.gameObject.SetActive(false);

        }
    }
}
