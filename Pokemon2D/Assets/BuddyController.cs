using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BuddyController : MonoBehaviour, ISwitchable
{
   
    private Charecter charecter; // Buddy
    public static BuddyController instance;

    [SerializeField] private PlayerController player;


    public Charecter Charecter => charecter;
    Transform ISwitchable.thecurrentChar => this.transform;

    public bool isActive { get; set; }

    private void Awake()
    {
        instance = this;

        charecter = GetComponent<Charecter>();
    }

    private void Start()
    {
        ActivateBuddy();
    }

    private void Update()
    {
        if (CharecterSwap.istogether == false) return;

        if (Vector3.Distance(transform.position, GameController.Instance.PlayerController.transform.position) > 3f)
        {
            transform.position = GameController.Instance.PlayerController.transform.position;
        }

        if (Vector3.Distance(transform.position, GameController.Instance.PlayerController.transform.position) > 15f)
        {
            CharecterSwap.istogether = true;
        }

        charecter.HandleUpdate();
    }

    // A method to Start the Buddy, Will automatically be called from Start 
    public void ActivateBuddy()
    {
        this.gameObject.SetActive(true);
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
        if (charecter.isActiveAndEnabled)
        {
            if (!charecter.IsMoving)
            {
                StartCoroutine(this.charecter.Move(moveVector, null, true));
            }
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

   
    public void IsSeperated()
    {
        isActive = false;
    }

    public void IsTogether()
    {
        isActive = true;
    }
}