using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Fader fader;

    public void PlayGame()
    {
        StartCoroutine(fade());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }

   private IEnumerator fade()
    {
        yield return fader.FadeIn(2f);
        yield return new WaitForSeconds(1f);
        yield return fader.FadeOut(2f);
    }
}
