using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSetActive : MonoBehaviour
{
    public GameObject[] objtoSpawn, currentgameObject;
   

    // Update is called once per frame
    void Update()
    {
        spawnObject(); 
    }

    public void spawnObject()
    {
        if (!currentgameObject[0].activeInHierarchy)
        {
            objtoSpawn[3].SetActive(true);
        }

    }
}
