using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followOnContact : MonoBehaviour
{
    private Charecter charecter; // Buddy
   
    public static followOnContact instance;

    [SerializeField] private PlayerController player;


    public Charecter Charecter => charecter;
    
    public bool isActive { get; set; }

    public bool isInRange;


    private void Awake()
    {
        instance = this;

        charecter = GetComponent<Charecter>();
   
    }

    private void Start()
    {
    
    }

    private void Update()
    {
       

        if (Vector3.Distance(transform.position, GameController.Instance.PlayerController.transform.position) > 3f && isInRange == true)
        {
            transform.position = GameController.Instance.PlayerController.transform.position;
        }

        charecter.HandleUpdate();
    }

    // A method to Start the Buddy, Will automatically be called from Start 
    public void ActivateBuddy()
    {
        this.transform.position = GameController.Instance.PlayerController.transform.position;
    }

    // A method to Stop the Buddy
    public void DeActivateBuddy()
    {

        this.gameObject.SetActive(false);

        StopAllCoroutines();
    }

    // Follows active player
    public void Follow(Vector2 movePosition)
    {
        Vector2 moveVector = movePosition - (Vector2)this.transform.position;
        moveVector = moveVector.Generalize();

        // When Buddy is not moving, move it again
        if (!charecter.IsMoving)
        {
            StartCoroutine(this.charecter.Move(moveVector, null, true));
        }


    }

    // Switch Method to switch active player from/to buddy
    public void OnSwitch(bool state)
    {
        player.playerActive = state;
        GetComponent<Party>().enabled = state;
        GetComponent<PlayerController>().enabled = state;
        GetComponent<BuddyController>().enabled = !state;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           isInRange = true;
           
            if (isInRange == true)
            {
                Follow(transform.position);

            }
        }
    }

}

