using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Sprite  dmg1Sprite, dmg2Sprite, dmg3Sprite ,dmg4Sprite, dmg5Sprite, dmg6Sprite;

    ButtonMash buttonMash;

    public SpriteRenderer thesr;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        buttonMash= GetComponent<ButtonMash>();

        thesr= GetComponent<SpriteRenderer>();
     
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            buttonMash.canMash = true;

            if (buttonMash.mash >= 12)
            {
                thesr.sprite = dmg1Sprite;
            }

            if (buttonMash.mash >= 24)
            {
                thesr.sprite = dmg2Sprite;
            }

            if (buttonMash.mash >= 36)
            {
                thesr.sprite = dmg3Sprite;
            }

            if (buttonMash.mash >= 48)
            {
                thesr.sprite = dmg4Sprite;
            }

            if (buttonMash.mash >= 60)
            {
                thesr.sprite = dmg5Sprite;
            }


            if (buttonMash.mash >= 72)
            {
                thesr.sprite = dmg6Sprite;
                this.gameObject.SetActive(false);
            }
        }
       
    }   

}
