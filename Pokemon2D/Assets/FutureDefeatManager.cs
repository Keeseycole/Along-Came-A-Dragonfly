using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutureDefeatManager : MonoBehaviour
{

    public GameObject earthTurtleDefeat, iceSnailDefeat, fireLionDefeat, greatCatfishDefeat;

    FutureDefeatManager futureDefeat;

    public GameObject sceneTrigger;

    elricFoundCutsceneManager elricFound;
    // Start is called before the first frame update
    void Start()
    {
        elricFound = FindObjectOfType<elricFoundCutsceneManager>();

        futureDefeat = FindObjectOfType<FutureDefeatManager>();

        fireLionDefeat = futureDefeat.gameObject.transform.GetChild(0).gameObject;

        iceSnailDefeat = futureDefeat.gameObject.transform.GetChild(1).gameObject;

        earthTurtleDefeat = futureDefeat.gameObject.transform.GetChild(2).gameObject;

        greatCatfishDefeat = futureDefeat.gameObject.transform.GetChild(3).gameObject;

        sceneTrigger = elricFound.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fireLionDefeat.activeInHierarchy && !iceSnailDefeat.activeInHierarchy
            && !earthTurtleDefeat.activeInHierarchy && !greatCatfishDefeat.activeInHierarchy) 
        { 
            sceneTrigger.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
}
