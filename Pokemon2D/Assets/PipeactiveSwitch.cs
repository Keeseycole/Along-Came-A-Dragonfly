using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeactiveSwitch : MonoBehaviour
{
    public List<GameObject> Trigger;

    public GameObject theTrigger;

    [SerializeField] WaterPipe pipe;

    public DoorSwitch theswitch;

    private void Update()
    {
        if (Trigger.Count <= 0)
        {
            GetPipe();
        }
    }


    public void GetPipe()
    {
        pipe.isflowing = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetPipe();
        theswitch.GetComponent<SpriteRenderer>().sprite = theswitch.instance.switchUp.GetComponent<SpriteRenderer>().sprite;
        theTrigger.SetActive(true);
    }
}
