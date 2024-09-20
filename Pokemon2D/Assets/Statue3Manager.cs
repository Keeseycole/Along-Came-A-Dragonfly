using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue3Manager : MonoBehaviour
{
    public List<GameObject> pieces;

    public GameObject scenetrigger;

    private void Update()
    {
        if (pieces[0].activeInHierarchy && pieces[1].activeInHierarchy && pieces[2].activeInHierarchy
              && pieces[3].activeInHierarchy && pieces[4].activeInHierarchy && pieces[5].activeInHierarchy
               && pieces[6].activeInHierarchy && pieces[7].activeInHierarchy)
        {
            scenetrigger.SetActive(true);
        }
    }
}
