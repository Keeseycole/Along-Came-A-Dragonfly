using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beastiery : MonoBehaviour
{

    enum beastInfo
    {
        Seen,
        Defeated,
        Caught
    }

    public GameObject beastiery, earthHab, fireHab, waterHab,iceHab, darknessHab, etherealHab, fishHab;


    [Header("Earth Creature Infos")]
    public GameObject[] earthCreatureInfos;


    [Header("Ice Creature Infos")]
    public GameObject[] iceCreatureInfos;

    [Header("Ethereal Creature Infos")]
    public GameObject[] etherealCreatureInfos;

    [Header("Fish Infos")]
    public GameObject[] fishInfos;


    public GameObject[] theHabitates;


    [Header("Earth Creature Buttons")]
    public Button[] Earthbuttons;


    [Header("Ethereal Creature Buttons")]
    public Button[] Etherealbuttons;


    [Header("Ice Creature Buttons")]
    public Button[] Icebuttons;


    [Header("Fish Buttons")]
    public Button[] FishButtons;

    public void EnableEarthEntryButton(int id)
    {
        Earthbuttons[id - 1].interactable = true;

    }

    public void EnableEtherealEntryButton(int id)
    {
        Etherealbuttons[id - 1].interactable = true;

    }

    public void EnableIceEntryButton(int id)
    {
        Icebuttons[id - 1].interactable = true;

    }

    public void EnableFishEntryButton(int id)
    {
        FishButtons[id - 1].interactable = true;

    }

    


    public void EnableEarthEntry(int id)
    {


        for (int i = 0; i < earthCreatureInfos.Length; i++)
        {
            earthCreatureInfos[i].SetActive(false);

        }

        // only enable coosen creature.
        earthCreatureInfos[id].SetActive(true);
    }

    public void EnableIceEntry(int id)
    {


        for (int i = 0; i < iceCreatureInfos.Length; i++)
        {
            iceCreatureInfos[i].SetActive(false);

        }

        // only enable coosen creature.
        iceCreatureInfos[id].SetActive(true);
    }

    public void EnableEtherealEntry(int id)
    {
       
        
        for (int i = 0; i < etherealCreatureInfos.Length; i++)
        {
            etherealCreatureInfos[i].SetActive(false);
            
        }

        // only enable coosen creature.
        etherealCreatureInfos[id].SetActive(true);
    }

    public void EnableFishEntry(int id)
    {


        for (int i = 0; i < fishInfos.Length; i++)
        {
            fishInfos[i].SetActive(false);

        }

        // only enable coosen creature.
        fishInfos[id].SetActive(true);
    }



    public void OpenBeasteary()
    {
        beastiery.SetActive(true);
    }

    public void CloseBeasteary()
    {
        beastiery.SetActive(false);
    }

    public void CloseEarthHabitate()
    {
        earthHab.SetActive(false);
    }

    public void CloseFireHabitate()
    {
        fireHab.SetActive(false);
    }

    public void CloseWaterHabitate()
    {
        waterHab.SetActive(false);
    }

    public void CloseIceHabitate()
    {
        iceHab.SetActive(false);
    }

    public void CloseDarknessHabitate()
    {
        darknessHab.SetActive(false);
    }

    public void CloseEtherealHabitate()
    {
        etherealHab.SetActive(false);
    }



    public void OpenEarthHabitate() 
    {
        earthHab.SetActive(true);
    }
    public void OpenWaterHabitate()
    {
        waterHab.SetActive(true);
    }

    public void OpenFireHabitate()
    {
        fireHab.SetActive(true);
    }

    public void OpenIceHabitate()
    {
        iceHab.SetActive(true);
    }

    public void OpenDarknessHabitate()
    {
        darknessHab.SetActive(true);
    }

    public void OpenEtharealHabitate()
    {
        etherealHab.SetActive(true);
    }

    public void OpenFishHabitate()
    {
        fishHab.SetActive(true);
    }



}
