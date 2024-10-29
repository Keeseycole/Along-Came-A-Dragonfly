using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block1Trigger : MonoBehaviour
{

    PictureBlockBlockers blockBlockers;
     PictureBlockTriggers blockTriggers;

    public GameObject blocker1;

    
    
    private void Start()
    {
        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

        blockBlockers = FindObjectOfType<PictureBlockBlockers>();

        blocker1 = blockBlockers.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock1")
        {
            
            blocker1.SetActive(true);
            this.gameObject.SetActive(false);
            
        }
    }
}
