using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cutscenes : MonoBehaviour
{
    protected void startCutscene()
    {
        GameController.Instance.GetAudioManager.MuteMusic();
    }

    protected void endCutscene()
    {
        GameController.Instance.GetAudioManager.UnMute();
    }
}

public class Cutscene : MonoBehaviour, IPlayerTriggerable
{
    [SerializeReference]
    [SerializeField] List<CutsceneAction> actions;

    [SerializeField] public GameObject cutscene;

    public bool triggerRepeatedly => false;

    public IEnumerator Play()
    {
        GameController.Instance.StateMachine.Push(CutsceneState.i);
        foreach (var action in actions)
        {
            yield return action.Play();
            
        }
        GameController.Instance.StateMachine.Pop();
        cutscene.SetActive(false);
    }
    public void AddAction(CutsceneAction action)
    {
        action.Name = action.GetType().ToString();
        actions.Add(action);
    }

    public void OnPlayerTriggered(PlayerController player)
    {
        player.Charecter.Animator.IsMoving= false;
        StartCoroutine(Play());
        
    }

    public void OnCompanionTriggered(CompanionController companion)
    {
        throw new System.NotImplementedException();
    }
}
