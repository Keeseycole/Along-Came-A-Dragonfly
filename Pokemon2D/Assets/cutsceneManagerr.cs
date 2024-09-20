using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneManagerr : MonoBehaviour
{
    public GameObject[] cutscenes;

    [SerializeField] AudioSource musicPlayer;

    AudioManager audiomanager;

    cutsceneManagerr theCutscenes;
    private void Start()
    {
        musicPlayer = FindObjectOfType<AudioSource>();

        audiomanager = FindObjectOfType<AudioManager>();     
    }

}
