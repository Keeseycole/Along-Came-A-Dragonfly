using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TRiggerableEvent : MonoBehaviour
{


    public void StartCutscene()
    {
       

        StartCoroutine(PlayCutscene());
    }


    public abstract IEnumerator PlayCutscene();
    
 
}
