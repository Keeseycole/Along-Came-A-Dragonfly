using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block3Trigger : MonoBehaviour
{

    PictureBlockBlockers blockBlockers;
    PictureBlockTriggers blockTriggers;

    public GameObject blocker;


    private void Start()
    {
      
        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

        blockBlockers = FindObjectOfType<PictureBlockBlockers>();

        blocker = blockBlockers.transform.GetChild(3).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock3")
        {
      
                blocker.SetActive(true);
                this.gameObject.SetActive(false);
            
        }
    }
}
