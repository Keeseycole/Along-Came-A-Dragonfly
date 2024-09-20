using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueMissionManager : MonoBehaviour
{
    Rescue1CutsceneManager rescue1Cutscene;
    Rescue2CutsceneManager rescue2Cutscene;
    Rescue3Cutescene rescue3Cutescene;
    Rescue4Cutscene Rescue4Cutscene;

  public  GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        rescue1Cutscene = FindObjectOfType<Rescue1CutsceneManager>();
        rescue2Cutscene =FindObjectOfType<Rescue2CutsceneManager>();
        rescue3Cutescene = FindObjectOfType<Rescue3Cutescene>();
        Rescue4Cutscene = FindObjectOfType<Rescue4Cutscene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rescue1Cutscene.isActiveAndEnabled && !rescue2Cutscene.isActiveAndEnabled
            && !rescue3Cutescene.isActiveAndEnabled && !Rescue4Cutscene.isActiveAndEnabled)
        {
            trigger.SetActive(true);
        }
    }
}
