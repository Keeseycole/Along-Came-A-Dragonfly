
using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class WindMaker : MonoBehaviour
{

    public float waitTime;

    public float runTime, rechargeTime;
    public float speed;

    [SerializeField] public PlayerController player;
    public bool isInTrigger;
    public bool isWindBlowing;

    public bool isLeft, isRight, isUp, isDown;

    public GameObject wind;



    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(WindRoutine());
    }
 
    private void OnTriggerStay2D(Collider2D other)
    {
        isInTrigger= true;
        // push player or buddy when wind is active
        if ((other.CompareTag("Player") || other.CompareTag("Buddy")) || other.CompareTag("Enemy")  && isWindBlowing)
        {
            

            if ((isDown == true && isWindBlowing && isInTrigger))
            {
                Vector2 pos = player.theRb.position;
                player.theRb.position += Vector2.down * speed * Time.deltaTime;
                player.theRb.MovePosition(pos);
            }

            if (isUp == true && isWindBlowing)
            {
                Vector2 pos = player.theRb.position;
                player.theRb.position += Vector2.up * speed * Time.deltaTime;
                player.theRb.MovePosition(pos);
            }

            if (isLeft == true && isWindBlowing)
            {
                Vector2 pos = player.theRb.position;
                player.theRb.position += Vector2.left * speed * Time.deltaTime;
                player.theRb.MovePosition(pos);
            }

            if (isRight == true && isWindBlowing)
            {
                Vector2 pos = player.theRb.position;
                player.theRb.position += Vector2.right * speed * Time.deltaTime;
                player.theRb.MovePosition(pos);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger= false;
    }
    public IEnumerator WindRoutine( )
    {
        // activates wind effect for a time, then deactivates wind for a time
        while (true)
        {
            wind.SetActive(true);
            isWindBlowing= true;
         // Debug.Log("is active");
            yield return new WaitForSeconds(runTime);
            wind.SetActive(false);
            isWindBlowing= false;
      //    Debug.Log("is inactive");
            yield return new WaitForSeconds(rechargeTime);
        }      
    }
}
