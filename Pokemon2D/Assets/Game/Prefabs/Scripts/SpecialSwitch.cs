using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSwitch : MonoBehaviour
{
    [SerializeField]
    public GameObject switchUp;
    [SerializeField]
    public GameObject switchDown;

    public bool isPressed = false;


    public bool isBlock;

    private DoorSetActive theDoor;


    [HideInInspector]
   

    private void Awake()
    {
        
    }
    private void Update()
    {

    }
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchUp.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = switchDown.GetComponent<SpriteRenderer>().sprite;
            isPressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
     
    }
}
