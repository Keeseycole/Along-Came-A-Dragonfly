using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block4Trigger : MonoBehaviour
{

    PictureBlockBlockers blockBlockers;
    PictureBlockTriggers blockTriggers;

    public GameObject blocker;


    private void Start()
    {

        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

        blockBlockers = FindObjectOfType<PictureBlockBlockers>();

        blocker = blockBlockers.transform.GetChild(6).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock4")
        {

            blocker.SetActive(true);
            this.gameObject.SetActive(false);

        }
    }
}
