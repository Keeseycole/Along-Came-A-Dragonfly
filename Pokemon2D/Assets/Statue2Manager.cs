using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue2Manager : MonoBehaviour
{
    public List<GameObject> pieces;

    public GameObject cutscenetrigger;


    Statue2Manager statue2Manager;

    private void Start()
    {
        statue2Manager = FindObjectOfType<Statue2Manager>();

      cutscenetrigger = statue2Manager.transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        if (pieces[0].activeInHierarchy && pieces[1].activeInHierarchy && pieces[2].activeInHierarchy
              && pieces[3].activeInHierarchy && pieces[4].activeInHierarchy && pieces[5].activeInHierarchy
               && pieces[6].activeInHierarchy && pieces[7].activeInHierarchy)
        {
            cutscenetrigger.SetActive(true);
        }
    }
}
