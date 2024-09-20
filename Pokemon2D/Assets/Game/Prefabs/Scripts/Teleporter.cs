using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public bool isDig;

    [SerializeField] private Transform destination;
    public Transform spawnpoint;
  

    public Transform GetDestination()
    {
        return spawnpoint;
    }

    
}
