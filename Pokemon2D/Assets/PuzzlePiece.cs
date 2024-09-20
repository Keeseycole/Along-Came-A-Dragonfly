using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    public string pieceStatus;

    public Rigidbody2D theRb;

    public PuzzlePiece i;

    private void Awake()
    {
        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      theRb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == other.gameObject.name && other.tag == "Slot")
        {
          transform.position =  other.transform.position;

            pieceStatus = "Locked";
            other.gameObject.isStatic= true;

        } 
    }
}
