using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BeastieryController : MonoBehaviour
{
    [SerializeField] Button[] thebuttons;

   

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
     EventSystem.current.SetSelectedGameObject(thebuttons[currentButton].gameObject);
    }
}
