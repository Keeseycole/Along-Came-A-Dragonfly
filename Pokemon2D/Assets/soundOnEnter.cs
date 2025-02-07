using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnEnter : MonoBehaviour
{

    AudioSource source;



    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

     if(other.tag == "Player")
        {
            source.Play();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            source.Stop();
        }

    }
}
