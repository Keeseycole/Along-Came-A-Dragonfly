using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEkricDefeatManager : TRiggerableEvent
{
    public Fader fader;

    public List<GameObject> enemies;

    public bool functionCalled = false;



    DarkElricHideManager darkElricHideManager;

    DarkEkricDefeatManager darlElricDefeat;
 

    // Start is called before the first frame update
    void Start()
    {
        darlElricDefeat = FindObjectOfType<DarkEkricDefeatManager>();

        darkElricHideManager = FindObjectOfType<DarkElricHideManager>();

        enemies[0] = darlElricDefeat.gameObject.transform.GetChild(1).gameObject;

    }

    private void Update()
    {
        

        if (enemies.Count <= 0)
        {

            if (!functionCalled)
            {

                functionCalled = true;

                StartCoroutine(PlayCutscene());

            }
        }
    }


    public override IEnumerator PlayCutscene()
    {
        

        yield return new WaitForSeconds(.2f);
      

        this.gameObject.SetActive(false);

      
    }
}
