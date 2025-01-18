using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockResetSwitch : MonoBehaviour
{

    public GameObject[] blocks;

    public Transform[] points;

    PictureBlockTriggers blockTriggers;

    public GameObject[] triggers;


    // Start is called before the first frame update
    void Start()
    {
        blockTriggers = FindObjectOfType<PictureBlockTriggers>();

        triggers[0] = blockTriggers.transform.GetChild(0).gameObject;
        triggers[1] = blockTriggers.transform.GetChild(1).gameObject;
        triggers[2] = blockTriggers.transform.GetChild(2).gameObject;
        triggers[3] = blockTriggers.transform.GetChild(3).gameObject;
        triggers[4] = blockTriggers.transform.GetChild(4).gameObject;
        triggers[5] = blockTriggers.transform.GetChild(5).gameObject;
        triggers[6] = blockTriggers.transform.GetChild(6).gameObject;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            blocks[0].transform.position = points[0].transform.position;
            blocks[1].transform.position = points[1].transform.position;
            blocks[2].transform.position = points[2].transform.position;
            blocks[3].transform.position = points[3].transform.position;
            blocks[4].transform.position = points[4].transform.position;
            blocks[5].transform.position = points[5].transform.position;
            blocks[6].transform.position = points[6].transform.position;

            triggers[0].gameObject.SetActive(true);
            triggers[1].gameObject.SetActive(true);
            triggers[2].gameObject.SetActive(true);
            triggers[3].gameObject.SetActive(true);
            triggers[4].gameObject.SetActive(true);
            triggers[5].gameObject.SetActive(true);
            triggers[6].gameObject.SetActive(true);

        }
    }
}
