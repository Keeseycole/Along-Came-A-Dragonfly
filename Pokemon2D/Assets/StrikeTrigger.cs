using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeTrigger : MonoBehaviour
{
    public AutoProjectile ligtning;


    public Transform spawnPoint;

    public float speed;


    public bool playerinRange;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            playerinRange = true;
            StartCoroutine(Eruption());
        }

    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            playerinRange = false;

        }
    }



    public IEnumerator Eruption()
    {

        while (playerinRange)
        {

            float posX = (transform.position.x) + (Random.Range(0, transform.localScale.x) - (transform.localScale.x / 2));
            float posY = (transform.position.y) + (Random.Range(0, transform.localScale.y) - (transform.localScale.y / 2));

            Vector2 tarPos = new Vector2(posX, posY);
            AutoProjectile newGameobject = Instantiate(ligtning, spawnPoint.transform.position, Quaternion.identity);

            newGameobject.tarPos = tarPos;

            yield return new WaitForSeconds(1f);
            //Destroy(newGameobject);



        }

    }
}
