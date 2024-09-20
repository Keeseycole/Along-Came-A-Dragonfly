using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Teams
{
    Blue,
    Red,
    Yellow
}

public enum EnemyStates
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{

    public EnemyStates currentState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
