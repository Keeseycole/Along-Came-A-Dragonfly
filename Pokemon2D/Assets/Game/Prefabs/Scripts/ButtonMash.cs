using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonMash : MonoBehaviour
{

  

   public int mash;

    public float countdown = .5f;

   bool iscounting;

   public bool pressed;

   public bool mashStart;

    public bool canMash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMash)
        {
            if (iscounting)
            {
                if (countdown >= 0)
                {

                    countdown -= Time.deltaTime;
                }
                else
                {
                    iscounting = false;
                }
            }


            if (countdown <= 0)
            {
                mash--;
                countdown = .5f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mashStart = true;

            }
            if (mashStart)
            {


                if (Input.GetKeyDown(KeyCode.Space) && !pressed)
                {

                    pressed = true;
                    mash++;

                }
                else if (Input.GetKeyUp(KeyCode.Space))

                {
                    iscounting = true;

                    pressed = false;


                }
                if (mash <= 0)
                {
                    mash = 0;
                    iscounting = false;
                    mashStart = false;

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

           canMash = true;

        }
       
    }



}
