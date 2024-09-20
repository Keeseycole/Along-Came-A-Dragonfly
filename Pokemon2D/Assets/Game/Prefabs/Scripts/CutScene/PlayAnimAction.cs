using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAnimAction : CutsceneAction
{
    [SerializeField] AnimationClip animToPlay;
    [SerializeField] Animation anim;


    public override IEnumerator Play()
    {
        yield return anim.clip = animToPlay;
        anim.Play();
    }


}
