using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaterPuzzle : MonoBehaviour
{
    public bool functionCalled = false;

    public List<GameObject> Enemies;

    [SerializeField] WaterPipe pipe;

    public GameObject trigger;


    private void Awake()
    {
        functionCalled= false;
    }
    private void Update()
    {
        if (Enemies.Count <= 0)
        {
          
            if (!functionCalled) 
            { 
                functionCalled = true;

                GetPipe();

                trigger.SetActive(true);
            }
        }
    }


    public void GetPipe()
    {
        

        pipe.isflowing= true;
        
    }

   

}
