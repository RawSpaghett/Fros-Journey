using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//THIS SCRIPT IS BASICALLY DEFUNCT AFTER SWITCHING TO UI TOOLKIT!!!! USE THE OTHER SCRIPT!


public partial class MainMenuEvents : MonoBehaviour
{}
    //============================== TOOLS ========================================================


/*
//==================== FX ================================================


    IEnumerator MainFadeOut(VisualTree root) //starts game specifically for the main menu
    {
        {
        float elapsed = 0;
        while (elapsed < FadeDuration)
        {
            elapsed += Time.deltaTime;
            root.style.opacity = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            yield return null;
        }
        root.style.opactiy = 0;
        }
        load.allowSceneActivation = true;
    }

    IEnumerator FadeIn(VisualTree root)
    {
        float elapsed = 0;
        while (elapsed < FadeDuration)
        {
            elapsed += Time.deltaTime;
            root.style.opacity = Mathf.Lerp(0, 1, elapsed / fadeDuration);
            yield return null;
        }
        root.style.opactiy = 1;
    }

    //============================== BUTTONS ========================================================
   public void StartGame() 
   {
    StartCoroutine(MainFadeOut());
   }

    public void ExitGame() //quits game
    {
    Application.Quit();
    }
}
*/
