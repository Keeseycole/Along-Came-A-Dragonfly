using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block5Trigger : MonoBehaviour
{

    PictureBlockBlockers blockBlockers;
    PictureBlockTriggers blockTriggers;

    public GameObject blocker;

    public GameObject blockTrigger;

    private void Awake()
    {
        
    }

    private void Start()
    {

        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

        blockBlockers = FindObjectOfType<PictureBlockBlockers>();

        blocker = blockBlockers.transform.GetChild(4).gameObject;

        blockTrigger = blockTriggers.transform.GetChild(4).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock5")
        {

            blocker.SetActive(true);
            this.gameObject.SetActive(false);

        }
    }
}
