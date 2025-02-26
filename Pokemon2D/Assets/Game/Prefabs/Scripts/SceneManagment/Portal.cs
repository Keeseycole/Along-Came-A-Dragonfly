using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] DesID PortalID;
    [SerializeField] Transform spawnPoint;

    PlayerController player;

    Fader fader;
    public void OnPlayerTriggered(PlayerController player)
    {
        player.Charecter.Animator.IsMoving = false;
        this.player = player;
        StartCoroutine(SwitchScene());
    }

    private void Start()
    {
      fader =  FindObjectOfType<Fader>();
    }
    IEnumerator SwitchScene()
    {
        DontDestroyOnLoad(gameObject);

         GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(1f);

        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        var portal = FindObjectsOfType<Portal>().First(x => x != this && x.PortalID == this.PortalID);
        //player.Charecter.SetPosToTile(portal.spawnPoint.position);

        yield return fader.FadeOut(1f);

        GameController.Instance.PauseGame(false);

        gameObject.SetActive(false);
    }

    public void OnCompanionTriggered(CompanionController companion)
    {
        throw new System.NotImplementedException();
    }

    public Transform SpawnPoint => spawnPoint;

    public bool triggerRepeatedly => false;
}

public enum DesID
{
    a,
    b,
    c,
    d,
    e,
    f,
    g,
    h,
    i,
    j,
    k, 
    l, 
    m,
    n,
    o,
    p,
    q,
    r,
    s,
    t, 
    u, 
    v, 
    w, 
    x,
    y,
    z,
    gPres1,
    gPres2,
    gPres3,
    gPres4,
    gPres5,
    gpres6,
    gpresForest,
    gPrison, 
    gInn,
    gTavern
    
}
   
