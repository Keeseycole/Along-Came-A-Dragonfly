using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationPortal : MonoBehaviour, IPlayerTriggerable
{
    // Teleports player without switching scenes
    [SerializeField] public DesID PortalID;
   
    [SerializeField] public Transform spawnPoint;

   

    PlayerController player;
    GameObject blocker;
    BuddyController buddy;

    [SerializeField] Fader fader;


    private void Start()
    {
        fader = FindObjectOfType<Fader>();
        player = FindObjectOfType<PlayerController>();
        buddy = FindObjectOfType<BuddyController>();
        blocker = player.transform.GetChild(1).gameObject;
    }

    public void OnPlayerTriggered(PlayerController player)
    {
         
            player.Charecter.Animator.IsMoving = false;
            this.player = player;
            StartCoroutine(Teleport());
               
    }

    IEnumerator Teleport()
    {
        blocker.SetActive(true);
        yield return fader.FadeIn(1f);
       
        buddy.DeActivateBuddy();
         var portal = FindObjectsOfType<LocationPortal>().First(x => x != this && x.PortalID == this.PortalID);
        player.Charecter.SetPositionAndSnapToTile(portal.spawnPoint.position);
        buddy.ActivateBuddy();
        yield return fader.FadeOut(1f);
        blocker.SetActive(false);

        // GameController.Instance.PauseGame(false);
    }

    public void StopBuddy()
    {
      buddy.Charecter.Animator.IsMoving = false;
        StartCoroutine(Teleport());
    }

    public void OnCompanionTriggered(CompanionController companion)
    {
        companion.Charecter.Animator.IsMoving = false;
        StartCoroutine(Teleport());
    }

    public Transform SpawnPoint => spawnPoint;

    public bool triggerRepeatedly => false;
}
