using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSwitch : MonoBehaviour
{
    public Transform objects;

    public Transform spawnpoint;


    [SerializeField]
    GameObject switchUp;
    [SerializeField]
    GameObject switchDown;

   public  MovableObject movableOblect;

    public GameObject thecollider;

    public bool ispresuresensative = false;

    private void Start()
    {
        movableOblect = FindObjectOfType<MovableObject>();

        //thecollider = movableOblect.transform.GetChild(6).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
         
            objects.position = spawnpoint.position;
            gameObject.GetComponent<SpriteRenderer>().sprite = switchDown.GetComponent<SpriteRenderer>().sprite;
            thecollider.SetActive(true);
        

            

            
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           

            if (ispresuresensative)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = switchUp.GetComponent<SpriteRenderer>().sprite;

            }
        }
    }
    }
    
