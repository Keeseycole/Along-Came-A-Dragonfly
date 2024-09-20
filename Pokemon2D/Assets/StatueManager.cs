using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueManager : MonoBehaviour
{
   RebuiltStatues rebuiltstatues;

    [SerializeField]GameObject statue1, statue2, statue3, statue4, statue5;


    DarkCatfishManager darkCatfishMan;

    DarkCatfishDefeat darkCatfishDefeatMan;

    StatueManager statueMan;

  public  GameObject trigger;

    public bool isComplete;

    public GameObject darkCatfish;

    public float timer;

    private void Awake()
    {
        rebuiltstatues = FindObjectOfType<RebuiltStatues>();

        statue1 = rebuiltstatues.transform.GetChild(0).gameObject;

        statue2 = rebuiltstatues.transform.GetChild(1).gameObject;

        statue3 = rebuiltstatues.transform.GetChild(2).gameObject;

        statue4 = rebuiltstatues.transform.GetChild(3).gameObject;

        statue5 = rebuiltstatues.transform.GetChild(4).gameObject;

        darkCatfishDefeatMan = FindObjectOfType<DarkCatfishDefeat>();

        statueMan = FindObjectOfType<StatueManager>();

        trigger = statueMan.gameObject.transform.GetChild(0).gameObject;

        darkCatfishMan = FindObjectOfType<DarkCatfishManager>();

    }

    private void Update()
    {
        if(statue1.activeInHierarchy && statue2.activeInHierarchy && statue3.activeInHierarchy &&
            statue4.activeInHierarchy && statue5.activeInHierarchy)
        {
           

            trigger.SetActive(true);
            Invoke("SetActiveDelay", .5f);

       
        }
    }

    public void SetActiveDelay()
    {
        this.gameObject.SetActive(false);
    }


}
