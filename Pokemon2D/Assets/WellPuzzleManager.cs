using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellPuzzleManager : MonoBehaviour
{
    public List<GameObject> pieces;



    public GameObject scenetrigger;

    public GameObject enemy;

    WellPuzzleManager wellPuzzleMan;

    FutureDefeatManager futureDefeatMan;


    private void Start()
    {
        futureDefeatMan = FindObjectOfType<FutureDefeatManager>();
        wellPuzzleMan = FindObjectOfType<WellPuzzleManager>();
        scenetrigger = wellPuzzleMan.transform.GetChild(5).gameObject;

        enemy = futureDefeatMan.gameObject.transform.GetChild(5).gameObject;
    }
    private void Update()
    {
        if (pieces[0].activeInHierarchy && pieces[1].activeInHierarchy && pieces[2].activeInHierarchy
              && pieces[3].activeInHierarchy && pieces[4].activeInHierarchy && pieces[5].activeInHierarchy
               && pieces[6].activeInHierarchy && pieces[7].activeInHierarchy && pieces[8].activeInHierarchy)
        {
            scenetrigger.SetActive(true);
            enemy.SetActive(true);
        }
    }
}
