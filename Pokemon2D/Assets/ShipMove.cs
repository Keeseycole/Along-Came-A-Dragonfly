using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{

    public Transform[] points;

    private int TarPoint;

    public float speed;
    public GameObject obToSpawn;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = transform.position;
        player.canMove = false;
        StartCoroutine(MoveShip());
    }

    public IEnumerator MoveShip()
    {
        
        yield return new WaitForSeconds(2f);

        if (transform.position == points[TarPoint].position)
        {
            IncreaseInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, points[TarPoint].position, speed * Time.deltaTime);
    }

    private void IncreaseInt()
    {
        TarPoint++;

        if (TarPoint >= points.Length)
        {
            TarPoint = 0;
            StopCoroutine(MoveShip());
            
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
      

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = transform.position;
            StartCoroutine(MoveShip());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
