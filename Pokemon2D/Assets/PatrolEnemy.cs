using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    public Transform[] points;

    public Rigidbody2D therb;

    public CharecterAnimator charAnim;

    private int TarPoint;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        charAnim= FindObjectOfType<CharecterAnimator>();
        therb= FindObjectOfType<Rigidbody2D>();

        TarPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == points[TarPoint].position)
        {
            IncreaseInt();
        }
      transform.position = Vector3.MoveTowards(transform.position, points[TarPoint].position, speed * Time.deltaTime);
    }

    private void IncreaseInt()
    {
        TarPoint++;

        if(TarPoint>= points.Length)
        {
            TarPoint= 0;
        }
    }
}
