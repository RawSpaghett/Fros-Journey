using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup fadeUI;
    public float fadeDuration = 3f;
    public int gameSceneIndex = 1; //change to proper scene index!
    private AsyncOperation load;

    public void Start()
    {
        ScreenFX.FadeIn(this,fadeUI,fadeDuration);
        StartCoroutine(PreLoad(gameSceneIndex));
    }

    IEnumerator PreLoad(int SceneIndex) //load the game before the player does anything, because its a vertical slice this wont impact performance
    {
        SceneManager.LoadScene(SceneIndex); //gives the percent of how finished it is
        load.allowSceneActivation = false; //pauses at 90%

        while(load.progress < 0.9f) //stops at 90%, in a different case we would use !load.isDone;
        {
            yield return null;
        }

        Debug.Log("Preload Complete"); 
    }

    IEnumerator MainFadeOut()
    {
        ScreenFX.FadeOut(this,fadeUI,fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        load.allowSceneActivation = true;
    }

   public void StartGame() //allows the load sequence to finish
   {
    StartCoroutine(MainFadeOut());//make a coroutine for this
   }

    public void Settings() //problem for later
    {}

    public void ExitGame() //quits game
    {
    Application.Quit();
    }
}
