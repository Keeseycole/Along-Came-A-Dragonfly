using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBlockTriggers : MonoBehaviour
{
    PictureBlockTriggers blockTrigger;

   public  List<GameObject> triggers;

    PictureDoor pictureDoor;

    private void Start()
    {
        pictureDoor = FindObjectOfType<PictureDoor>();

       // triggers[0] = blockTrigger.transform.GetChild(1).gameObject;

        blockTrigger = FindObjectOfType<PictureBlockTriggers>();
    }
    private void Update()
    {
        if (!triggers[0].activeInHierarchy && !triggers[1].activeInHierarchy && 
            !triggers[2].activeInHierarchy && !triggers[3].activeInHierarchy &&
            !triggers[4].activeInHierarchy && !triggers[5].activeInHierarchy &&
            !triggers[6].activeInHierarchy)
        {
            pictureDoor.gameObject.SetActive(false);
        }
    }
}
