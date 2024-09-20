using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePuzzleManager : MonoBehaviour
{
   public List<GameObject> pieces;

    public GameObject scenetrigger;

    StatuePuzzleManager statuePuzzleMan;

   



    private void Start()
    {
        statuePuzzleMan = FindObjectOfType<StatuePuzzleManager>();

        scenetrigger = statuePuzzleMan.transform.GetChild(3).gameObject;
    }

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


