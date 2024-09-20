using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField] Button[] memberbuttons;



    // Start is called before the first frame update
    void Start()
    {
        ButtonInit();
    }

    void ButtonInit()
    {
        Enter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enter(int currentButton = 0)
    {
        EventSystem.current.SetSelectedGameObject(memberbuttons[currentButton].gameObject);
    }
}
