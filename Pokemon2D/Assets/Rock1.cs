using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock1 : MonoBehaviour
{

    LavaRocks lavaRocks;

  public  GameObject rock1;
    // Start is called before the first frame update
    void Start()
    {
        lavaRocks = FindObjectOfType<LavaRocks>();

        rock1 = lavaRocks.gameObject.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Lava")
        {
            rock1.SetActive(true);
        }
    }
}
