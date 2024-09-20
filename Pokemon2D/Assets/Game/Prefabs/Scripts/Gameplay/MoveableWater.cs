using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableWater : MonoBehaviour, Interactable
{
    bool isJumpingWater = false;

    public bool triggerRepeatedly => true;

    public IEnumerator Interact(Transform initer)
    {
       

        var animator = initer.GetComponent<CharecterAnimator>();
        if (animator.IsSurfing || isJumpingWater)
            yield break;

        yield return DialogueManager.Instance.ShowDialogText("The water is Deep Blue.");

      
     
            int selectedChoice = 0;

            yield return DialogueManager.Instance.ShowDialogText($"Jump in?",
                choices: new List<string>() { "Yes", "No" },
                onchoiceSelected: (selection) => selectedChoice = selection);
            
            //GameController.Instance.StateMachine.Pop();

            if (selectedChoice == 0)
            {
                //Yes
            

               
               var dir = new Vector3(animator.MoveX, animator.MoveY);
                var targetPos = initer.position + dir;

                isJumpingWater = true;
                initer.DOJump(targetPos, 0.3f, 1, 0.5f).WaitForCompletion();
                isJumpingWater = false;

                animator.IsSurfing = true;
           // GameController.Instance.StateMachine.Pop();

        }
       
    }

}
