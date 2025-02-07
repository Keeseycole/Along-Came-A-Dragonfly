using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{

   public GameObject bedtriggers;

    public GameObject innKeeper;

    public GameObject innKeeperAfterPay;
    private void Awake()
    {
        innKeeper = FindObjectOfType<Innkeeper>().gameObject;
    }
    public IEnumerator Heal(Transform player, Dialogue dialogue)
    {
      
        int selectedChoice = 0;
        //Debug.Log(" Fishing trigger game Dialogue Manager Instance", DialogueManager.Instance.gameObject);
        yield return DialogueManager.Instance.ShowDialogText($"Do you want to sleep here?",
            choices: new List<string>() { "Yes", "No" },
            onchoiceSelected: (selection) => selectedChoice = selection);

        if (selectedChoice == 0)
        {
           yield return Fader.i.FadeIn(0.5f);

            var playerParty = player.GetComponent<Party>();
            playerParty.Creatures.ForEach(p => p.Heal());
            playerParty.PartyUpdated();

            yield return Fader.i.FadeOut(0.5f);

            yield return DialogueManager.Instance.ShowDialogText($"You feel well-rested");
            bedtriggers.SetActive(false);

            innKeeper.SetActive(true);
            innKeeperAfterPay.SetActive(false);
        } 

       
    }
}
