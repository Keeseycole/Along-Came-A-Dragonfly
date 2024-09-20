using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static CharecterAnimator;

public class FOVEnemy : MonoBehaviour
{

    [SerializeField] GameObject exclimation;
    [SerializeField] protected GameObject fov;

    Charecter charecter;

    [SerializeField] Transform spawnPoint;

    [SerializeField] Fader fader;

    public PlayerController player;

    public BuddyController buddy;
    [SerializeField] Dialogue dialogue;



    public bool triggerRepeatedly => throw new System.NotImplementedException();


    // Start is called before the first frame update
    void Start()
    {
        fader = FindObjectOfType<Fader>();
        player = FindObjectOfType<PlayerController>();
        buddy = FindObjectOfType<BuddyController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerCaught(PlayerController player)
    {

        // show exclamation
       // exclimation.SetActive(true);
       // yield return new WaitForSeconds(0.5f);
        //exclimation.SetActive(false);

      
        //walk twords player
       // var diff = player.transform.position - transform.position;
      //  var movevec = diff - diff.normalized;
       // movevec = new Vector2(Mathf.Round(movevec.x), Mathf.Round(movevec.y));

       // yield return charecter.Move(movevec);

        yield return DialogueManager.Instance.ShowDialogue(dialogue);
        StartCoroutine(Teleport());
       
    }

    public void SetFovRotation(FacingDirection dir)
    {
        float angle = 0f;
        if (dir == FacingDirection.Right)
            angle = 90f;
        else if (dir == FacingDirection.Up)
            angle = 180f;
        else if (dir == FacingDirection.Left)
            angle = 270f;

        fov.transform.eulerAngles = new Vector3(0, 0, angle);

    }

   

    IEnumerator Teleport()
    {
        // GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);
        player.Charecter.Animator.IsMoving = false;
        buddy.DeActivateBuddy();

        player.transform.position = spawnPoint.transform.position;
        buddy.ActivateBuddy();
        yield return fader.FadeOut(0.5f);


        // GameController.Instance.PauseGame(false);
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            StartCoroutine(PlayerCaught(player));
        }
    }


}
