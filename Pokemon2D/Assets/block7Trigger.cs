using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block7Trigger : MonoBehaviour
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



        blockTrigger = blockTriggers.transform.GetChild(6).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlideBlock7")
        {

            this.gameObject.SetActive(false);

        }
    }
}
