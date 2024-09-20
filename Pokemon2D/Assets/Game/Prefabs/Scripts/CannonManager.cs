using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    public List<GameObject> Cannons;


    public GameObject objToSpawn;

    public int offNum;

    public object CaptureState()
    {
        throw new NotImplementedException();
    }

    public void RestoreState(object state)
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if (Cannons.Count <= 0)
        {
            objToSpawn.SetActive(true);
        }
    }

}
