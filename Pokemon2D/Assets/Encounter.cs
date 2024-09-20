using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Encounter : TrainerController

{ 
   public float waitTime = .5f;

   public  SpawnManager spawnmanager;

   public bool spawn1, spawn2, spawn3, spawn4;

    public override void BattleLost()
    {
        base.BattleLost();
   
            if (spawn1)
            {
                spawnmanager.enemyCount--;
            }

            if (spawn2)
            {
                spawnmanager.enemyCount2--;
            }
        Destroy(gameObject);     

    }

}


