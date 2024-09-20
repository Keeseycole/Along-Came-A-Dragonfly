using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallnHoleManager : MonoBehaviour
{
    public List<GameObject> Enemies;

    public GameObject trigger;


    FireLionManager fireLionMan;



    private void Start()
    {
        fireLionMan= FindObjectOfType<FireLionManager>();

        trigger = fireLionMan.gameObject.transform.GetChild(0).gameObject;

    }

    private void Update()
    {
        if (Enemies.Count <= 0)
        {
            trigger.SetActive(true);
        }
    }
}
